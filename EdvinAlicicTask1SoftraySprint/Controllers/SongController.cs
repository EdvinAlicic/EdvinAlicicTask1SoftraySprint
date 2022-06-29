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
            if(!await _songInfoRepository.CategoryExitsAsync(categoryId))
            {
                return NotFound();
            }
            var song = await _songInfoRepository.GetSongForCategory(categoryId, songId);

            if(song == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDto>(song));
        }
    }
}
