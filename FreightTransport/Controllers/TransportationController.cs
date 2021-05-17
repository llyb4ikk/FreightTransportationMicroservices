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
    public class TransportationController : Controller
    {
        private readonly ITransportationService _service;
        public TransportationController(ITransportationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddTransportation")]
        public async Task<IActionResult> AddCar(TransportationDTO transportationDto)
        {
            var result = await _service.AddTransportationAsync(transportationDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllTransportations")]
        public async Task<IActionResult> GetAllTransportations()
        {
            var result = await _service.GetAllTransportationsAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetTransportationById/{id}")]
        public async Task<IActionResult> GetTransportationById(int id)
        {
            var result = await _service.GetTransportationByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateTransportation")]
        public async Task<IActionResult> UpdateTransportation(TransportationDTO transportationDto)
        {
            var result = await _service.EditTransportationAsync(transportationDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteTransportation/{id}")]
        public async Task<IActionResult> DeleteTransportation(int id)
        {
            var result = await _service.DeleteTransportationAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllTransportationsTable")]
        public async Task<IActionResult> GetAllTransportationsTable()
        {
            var result = await _service.GetAllTransportationsTable();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GettransportationDetailsById/{id}")]
        public async Task<IActionResult> GettransportationDetailsById(int id)
        {
            var result = await _service.GetTransportationDetailsById(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("NextStage/{transportationId}")]
        public async Task<IActionResult> NextStage(int transportationId)
        {
            var result = await _service.NextStageAsync(transportationId);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}