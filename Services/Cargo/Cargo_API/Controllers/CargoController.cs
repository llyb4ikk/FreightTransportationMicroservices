using System.Threading.Tasks;
using Cargo_Application.Cargo.Commands;
using Cargo_Application.Cargo.Queries;
using Cargo_Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cargo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : Controller
    {
        private readonly IMediator _mediator;
        public CargoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargos()
        {
            var result = await _mediator.Send(new GetAllCargosQuery());
            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargo(CargoDTO cargoDto)
        {
            var result = await _mediator.Send(new CreateCargoCommand(cargoDto));
            if (result) return Ok();

            return NotFound();
        }

        [HttpGet("GetCargosTable")]
        public async Task<IActionResult> GetCargosTable()
        {
            var result = await _mediator.Send(new GetAllCargosInformationQuery());
            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [Route("CargosByTransportation/{transportationId}")]
        public async Task<IActionResult> CargosByTransportation(int transportationId)
        {
            var result = await _mediator.Send(new GetCargosByTransportationQuery(transportationId));
            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [Route("CargosInformationByTransportation/{transportationId}")]
        public async Task<IActionResult> CargosInformationByTransportation(int transportationId)
        {
            var result = await _mediator.Send(new GetCargosInformationByTransportationQuery(transportationId));
            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPut]
        [Route("SetCargoTransportation/{transportationId}")]
        public async Task<IActionResult> SetCargoTransportation([FromBody] int cargoId, int? transportationId)
        {
            var result = await _mediator.Send(new SetCargoTransportionCommand(cargoId, transportationId));
            if (result) return Ok();

            return NotFound();
        }
    }
}