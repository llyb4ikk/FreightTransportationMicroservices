using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarDriverController : Controller
    {
        private readonly ICarDriverService _service;
        public CarDriverController(ICarDriverService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddCarDriver")]
        public async Task<IActionResult> AddCarDriver(CarDriverDTO carDriverDto)
        {
            var result = await _service.AddCarDriverAsync(carDriverDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllCarDrivers")]
        public async Task<IActionResult> GetAllCarDrivers()
        {
            var result = await _service.GetAllCarDriversAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}