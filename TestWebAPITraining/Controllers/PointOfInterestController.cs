using Microsoft.AspNetCore.Mvc;
using TestWebAPITraining.Models;

namespace TestWebAPITraining.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/[controller]")]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterest>> GetPointsOfInterests(int cityId)
        {
            var cityToReturn = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            var poi = cityToReturn.PointOfInterests;
            return Ok(poi);
        }


        [HttpGet("{id}")]
        public ActionResult<PointOfInterest> GetPointOfInterest(int cityId,int id)
        {
            var cityToReturn = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            var poi = cityToReturn.PointOfInterests.FirstOrDefault(p=>p.Id==id);
            if (poi == null)
            {
                return NotFound();
            }
            return Ok(poi);
        }
    }
}
