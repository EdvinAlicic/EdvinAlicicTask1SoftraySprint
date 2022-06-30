using AutoMapper;
using EdvinAlicicTask1SoftraySprint.Models;
using EdvinAlicicTask1SoftraySprint.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdvinAlicicTask1SoftraySprint.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/song")]
    public class SongController : ControllerBase
    {
        private readonly ISongInfoRepository _songInfoRepository;
        private readonly IMapper _mapper;

        public SongController(ISongInfoRepository songInfoRepository, IMapper mapper)
        {
            _songInfoRepository = songInfoRepository ?? throw new ArgumentNullException(nameof(songInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSongsForCategory(int categoryId)
        {
            var songs = await _songInfoRepository.GetSongsForCategory(categoryId);
            return Ok(_mapper.Map<IEnumerable<SongDto>>(songs));
        }

        [HttpGet("{songId}", Name = "GetSong")]
        public async Task<ActionResult<SongDto>> GetSongForCategory(int categoryId, int songId)
        {
            if (!await _songInfoRepository.CategoryExitsAsync(categoryId))
            {
                return NotFound();
            }
            var song = await _songInfoRepository.GetSongForCategory(categoryId, songId);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDto>(song));
        }

        [HttpPost]
        public async Task<ActionResult<SongDto>> CreateSong(int categoryId, SongForCreationDto song)
        {
            if (!await _songInfoRepository.CategoryExitsAsync(categoryId))
            {
                return NotFound();
            }

            var finalSong = _mapper.Map<Entities.Song>(song);

            await _songInfoRepository.AddSongForCategoryAsync(categoryId, finalSong);

            await _songInfoRepository.SaveChangesAsync();

            var createdSong = _mapper.Map<Models.SongDto>(finalSong);

            return CreatedAtRoute("GetSong", new
            {
                categoryId = categoryId,
                songId = createdSong.Id
            }, createdSong);
        }

        [HttpPut("{songid}")]
        public async Task<ActionResult> UpdateSong(int categoryId, int songId, SongForUpdateDto song)
        {
            if (!await _songInfoRepository.CategoryExitsAsync(categoryId))
            {
                return NotFound();
            }

            var songEntity = await _songInfoRepository.GetSongForCategory(categoryId, songId);
            if (songEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(song, songEntity);

            await _songInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{songid}")]
        public async Task<ActionResult> DeleteSong(int categoryId, int songId)
        {
            if(!await _songInfoRepository.CategoryExitsAsync(categoryId))
            {
                return NotFound();
            }

            var songEntity = await _songInfoRepository.GetSongForCategory(categoryId, songId);

            if(songEntity == null)
            {
                return NotFound();
            }

            _songInfoRepository.DeleteSongForCategoryAsync(songEntity);

            await _songInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
