using FreightTransport_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface ITransportationRepository : IGenericRepository<Transportation>
    {
        Task<IEnumerable<Transportation>> GetAllWithCities();
        Task<Transportation> GetAllWithCitiesById(int id);
    }
}
