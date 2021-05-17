using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
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

        [HttpGet]
        [Route("GetAllFreeCarDrivers")]
        public async Task<IActionResult> GetAllFreeCarDrivers()
        {
            var result = await _service.GetAllFreeCarDrivers();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetCarDriverById/{id}")]
        public async Task<IActionResult> GetCarDriverById(int id)
        {
            var result = await _service.GetCarDriverByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateCarDriver")]
        public async Task<IActionResult> UpdateCarDriver(CarDriverDTO carDriverDto)
        {
            var result = await _service.EditCarDriverAsync(carDriverDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteCarDriver/{id}")]
        public async Task<IActionResult> DeleteCarDriver(int id)
        {
            var result = await _service.DeleteCarDriverAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }
    }
}