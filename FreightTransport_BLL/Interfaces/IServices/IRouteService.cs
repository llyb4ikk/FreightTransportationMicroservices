using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface IRouteService
    {
        Task<RouteDTO> GetRouteByIdAsync(int id);
        Task<RouteInfoDTO> GetRouteInfoByIdAsync(int id);
        Task<IEnumerable<RouteDTO>> GetAllRoutesAsync();
        Task<IEnumerable<RouteInfoDTO>> GetAllRoutesInfoAsync();
        Task<RouteDTO> AddRouteAsync(RouteDTO routeDto);
        Task<RouteDTO> EditRouteAsync(RouteDTO routeDto);
        Task<bool> DeleteRouteAsync(int id);
    }
}