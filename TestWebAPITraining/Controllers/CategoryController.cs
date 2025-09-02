using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPITraining.Models;

namespace TestWebAPITraining.Controllers
{
    [ApiController]
    //[Route("api/v{version:apiVersion}/categories")]
    [Route("api/v{version:apiVersion}/Categories")]
    [Authorize]
    [ApiVersion(2)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository=categoryRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categoris = await _categoryRepository.GetAllCategoriesAsync();
            //return Ok(categoris);   
            return Ok(_mapper.Map<IEnumerable<CategoryWithoutPies>>(categoris));
        }
    }
}
