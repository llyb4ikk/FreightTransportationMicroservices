using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface IDriverSalaryService
    {
        Task<DriverSalaryDTO> GetDriverSalaryByIdAsync(int id);
        Task<IEnumerable<DriverSalaryDTO>> GetAllDriverSalarysAsync();
        Task<DriverSalaryDTO> AddDriverSalaryAsync(DriverSalaryDTO carDto);
        Task<DriverSalaryDTO> EditDriverSalaryAsync(DriverSalaryDTO carDto);
        Task<bool> DeleteDriverSalaryAsync(int id);

        Task<IEnumerable<DriverSalaryInformationDTO>> GetDriverSalariesBytransportationAsync(int transportationId);

    }
}