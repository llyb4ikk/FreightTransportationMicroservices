using FreightTransport_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        Task<IEnumerable<Cargo>> GetAllCargosWithOwnersByTransportationId(int id);
        Task<IEnumerable<Cargo>> GetAllCargosWithOwners();
        Task<IEnumerable<Cargo>> GetAllCargosWithOwnersWithoutTransportation();

    }
}
