using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetCityById/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var result = await _service.GetCityByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetCitiesByRoute/{region}")]
        public async Task<IActionResult> GetCitiesByRoute(Region region)
        {
            var result = await _service.GetCitiesByRegion(region);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}