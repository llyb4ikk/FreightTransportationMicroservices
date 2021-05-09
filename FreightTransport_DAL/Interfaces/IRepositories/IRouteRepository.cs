using FreightTransport_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        Task<Route> GetRouteInfoById(int id);
        Task<IEnumerable<Route>> GetAllRoutesInfo();
    }
}
