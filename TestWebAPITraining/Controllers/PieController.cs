using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TestWebAPITraining.Models;

namespace TestWebAPITraining.Controllers
{
    [ApiController]
    [Route("api/pies")]
    //[Route("api/v{version:apiVersion}/pies")]
    [ApiVersion(1)]
    //[ApiVersion(2)]
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        const int maxProductsPageSize = 20;
        public PieController(IPieRepository pieRepository) 
        {
         _pieRepository = pieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPies(int pageNumber = 1, int pageSize = 2)
        {
            if (pageSize > maxProductsPageSize)
            {
                pageSize = maxProductsPageSize;
            }
            return Ok(await  _pieRepository.AllPiesAsync(pageNumber, pageSize));
        }
        [HttpGet("piesoftheweek")]
        [ApiVersion(0.1, Deprecated = true)]
        public async Task<IActionResult> GetPiesOfTheWeek()
        {
            return Ok(await _pieRepository.PiesOfTheWeekAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPies(int id)
        {
            return Ok(await _pieRepository.GetPieByIdAsync(id));
        }
        //[HttpGet("{CategoryName}")]
        //public async Task<IActionResult> GetPiesOfcategory(string CategoryName)
        //{
        //    return Ok();
        //   // return Ok(await _pieRepository.AllPiesAsync.Where(p => p.Category.CategoryName == CategoryName));
        //}
    }
}
