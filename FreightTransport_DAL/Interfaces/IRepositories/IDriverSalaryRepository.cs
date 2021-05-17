using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_DAL.Entities;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface IDriverSalaryRepository: IGenericRepository<DriverSalary>
    {
        Task<IEnumerable<DriverSalary>> GetDriverSalaryInfo(int transportationId);
    }
}