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
    public class CargoController : Controller
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddCargo")]
        public async Task<IActionResult> AddCargo(CargoDTO cargoDto)
        {
            var result = await _service.AddCargoAsync(cargoDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllCargos")]
        public async Task<IActionResult> GetAllCargos()
        {
            var result = await _service.GetAllCargosAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetCargoById/{id}")]
        public async Task<IActionResult> GetCargoById(int id)
        {
            var result = await _service.GetCargoByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateCargo")]
        public async Task<IActionResult> UpdateCargo(CargoDTO cargoDto)
        {
            var result = await _service.EditCargoAsync(cargoDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteCargo/{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var result = await _service.DeleteCargoAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllCargosWithOwnersByTransportationId/{id}")]
        public async Task<IActionResult> GetAllCargosWithOwnersByTransportationId(int id)
        {
            var result = await _service.GetAllCargosWithOwnersByTransportationId(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllCargosWithOwner")]
        public async Task<IActionResult> GetAllCargosWithOwner()
        {
            var result = await _service.GetAllCargosWithOwner();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("AddCargoToTransportation/{transportationId}")]
        public async Task<IActionResult> AddCargoToTransportation([FromBody]int cargoId, int transportationId)
        {
            var result = await _service.AddCargoToTransportation(cargoId, transportationId);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("RemoveCargoToTransportation")]
        public async Task<IActionResult> RemoveCargoToTransportation([FromBody] int cargoId)
        {
            var result = await _service.RemoveCargoToTransportation(cargoId);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllCargosWithOwnersWithputTransportation")]
        public async Task<IActionResult> GetAllCargosWithOwnersWithputTransportation()
        {
            var result = await _service.GetAllCargosWithOwnersWithputTransportation();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}