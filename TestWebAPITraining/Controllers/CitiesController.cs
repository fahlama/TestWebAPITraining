using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TestWebAPITraining.Models;

namespace TestWebAPITraining.Controllers
{
    [ApiController]
    [Route("api/cities")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
       public ActionResult<IEnumerable<City>> GetCities()
        {
            return Ok(CityDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        [ApiVersion(0.1, Deprecated = true)]
        public ActionResult<City> GetCity(int id)
        {
            var temp = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(temp != null) { return Ok(temp); }
            else { return NotFound(); }
            
        }
    }
}
