using System.Collections.Generic;
using System.Threading.Tasks;
using Cargo_Domain.Entities;
using Cargo_Infrastructure.Models;

namespace Cargo_Infrastructure.Interfaces.IRepositories
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        Task<IEnumerable<Cargo>> GetByTransprtationId(int id);
        Task<IEnumerable<CargoInformationModel>> GetCargosByTransportationId(int transportationId);
        Task<IEnumerable<CargoInformationModel>> GetAllCagosInformation();
    }
}