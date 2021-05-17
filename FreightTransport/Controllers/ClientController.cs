using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient(UserDTO userDto)
        {
            var result = await _service.AddUserAsync(userDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _service.GetAllUsersAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetClientById/{id}")]
        public async Task<IActionResult> v(int id)
        {
            var result = await _service.GetUserByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateClient")]
        public async Task<IActionResult> UpdateClient(UserDTO userDto)
        {
            var result = await _service.EditUserAsync(userDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }
    }
}