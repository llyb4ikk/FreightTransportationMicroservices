using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : Controller
    {
        private readonly IRouteService _service;
        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddRoute")]
        public async Task<IActionResult> AddRoute(RouteDTO routeDto)
        {
            var result = await _service.AddRouteAsync(routeDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllRoutes")]
        public async Task<IActionResult> GetAllRoutes()
        {
            var result = await _service.GetAllRoutesAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllRoutesInfo")]
        public async Task<IActionResult> GetAllRoutesInfo()
        {
            var result = await _service.GetAllRoutesInfoAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetRouteById/{id}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            var result = await _service.GetRouteByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetRouteInfoById/{id}")]
        public async Task<IActionResult> GetRouteInfoById(int id)
        {
            var result = await _service.GetRouteInfoByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateRoute")]
        public async Task<IActionResult> UpdateRoute(RouteDTO routeDto)
        {
            var result = await _service.EditRouteAsync(routeDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteRoute/{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var result = await _service.DeleteRouteAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }
    }
}