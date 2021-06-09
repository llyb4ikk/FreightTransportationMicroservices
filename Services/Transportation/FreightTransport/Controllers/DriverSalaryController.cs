using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FreightTransport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverSalaryController : Controller
    {
        private readonly IDriverSalaryService _service;
        public DriverSalaryController(IDriverSalaryService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddDriverSalary")]
        public async Task<IActionResult> AddDriverSalary(DriverSalaryDTO driverSalaryDto)
        {
            var result = await _service.AddDriverSalaryAsync(driverSalaryDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetAllDriverSalarys")]
        public async Task<IActionResult> GetAllDriverSalarys()
        {
            var result = await _service.GetAllDriverSalarysAsync();
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetDriverSalaryById/{id}")]
        public async Task<IActionResult> GetDriverSalaryById(int id)
        {
            var result = await _service.GetDriverSalaryByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpPut]
        [Route("UpdateDriverSalary")]
        public async Task<IActionResult> UpdateDriverSalary(DriverSalaryDTO driverSalaryDto)
        {
            var result = await _service.EditDriverSalaryAsync(driverSalaryDto);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }

        [HttpDelete]
        [Route("DeleteDriverSalary/{id}")]
        public async Task<IActionResult> DeleteDriverSalary(int id)
        {
            var result = await _service.DeleteDriverSalaryAsync(id);
            if (result)
                return Ok();
            return NotFound("empty");
        }

        [HttpGet]
        [Route("GetDriverSalariesInformationByTransportation/{tramsportationId}")]
        public async Task<IActionResult> GetDriverSalariesInformationByTransportation(int tramsportationId)
        {
            var result = await _service.GetDriverSalariesBytransportationAsync(tramsportationId);
            if (result != null)
                return Ok(result);
            return NotFound("empty");
        }
    }
}