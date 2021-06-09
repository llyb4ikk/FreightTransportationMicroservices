using System.Linq;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _service;
        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarDTO carDto)
        {
            var result = await _service.AddCarAsync(carDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarDrivers()
        {
            var result = await _service.GetAllCarsAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _service.GetCarByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(CarDTO carDto)
        {
            var result = await _service.EditCarAsync(carDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _service.DeleteCarAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetFreeCarsOfSelectedType/{carType}")]
        public async Task<IActionResult> GetFreeCarsOfSelectedType(CarType carType)
        {
            var result = await _service.GetFreeCarsOfSelectedType(carType);
            if (result.Count() == 0)
                return NoContent();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}
