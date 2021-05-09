using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface IRouteService
    {
        Task<RouteModel> GetRouteById(int id);
        Task<RouteInfoModel> GetRouteInfoById(int id);
        Task<IEnumerable<RouteInfoModel>> GetAllRoutesInfo();
        Task<IEnumerable<RouteModel>> GetAllRoutes();
        Task<bool> AddRoute(RouteModel routeModel);
        Task<bool> UpdateRoute(RouteModel routeModel);
        Task<bool> DeleteRoute(int id);
    }
}