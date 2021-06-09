using System.Threading.Tasks;
using Cargo_Application.Client.Commands;
using Cargo_Application.Client.Queries;
using Cargo_Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cargo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var query = new GetAllClientsQuery();
            var result = await _mediator.Send(query);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDTO clientDto)
        {
            var commnd = new CreateClientCommand(clientDto);
            var result = await _mediator.Send(commnd);
            if (result)
                return Ok(result);

            return NotFound();
        }
    }
}