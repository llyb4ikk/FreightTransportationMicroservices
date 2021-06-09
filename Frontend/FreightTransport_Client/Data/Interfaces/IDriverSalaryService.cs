using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface IDriverSalaryService
    {
        Task<DriverSalaryModel> GetDriverSalaryById(int id);
        Task<IEnumerable<DriverSalaryModel>> GetAllDriverSalaryModels();
        Task<bool> AddDriverSalary(DriverSalaryModel driverSalaryModel);
        Task<bool> UpdateDriverSalary(DriverSalaryModel driverSalaryModel);
        Task<bool> DeleteDriverSalary(int id);
        Task<IEnumerable<DriverSalaryInfoModel>> GetDriverSalariesInformationByTransportation(int transportationId);
    }
}