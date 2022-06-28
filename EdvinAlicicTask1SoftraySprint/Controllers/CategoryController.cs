using AutoMapper;
using EdvinAlicicTask1SoftraySprint.Models;
using EdvinAlicicTask1SoftraySprint.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdvinAlicicTask1SoftraySprint.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ISongInfoRepository _songInfoRepository;
        private readonly IMapper _mapper;

        public CategoryController(ISongInfoRepository songInfoRepository, IMapper mapper)
        {
            _songInfoRepository = songInfoRepository ?? throw new ArgumentNullException(nameof(songInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoryEntities = await _songInfoRepository.GetCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoryEntities));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _songInfoRepository.GetCategoryAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<CategoryDto>(category));
            }
        }
    }
}
