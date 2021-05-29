using System.Threading.Tasks;
using Location.Enums;
using Location.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Location.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("GetCityById/{id}")]
        public async Task<IActionResult> GetCityById(string id)
        {
            var result = await _cityService.GetCityById(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [Route("GetCitiesByRegion/{region}")]
        public async Task<IActionResult> GetCityById(Region region)
        {
            var result = await _cityService.GetCitiesByRegion(region);

            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}