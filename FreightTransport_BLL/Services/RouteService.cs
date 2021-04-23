using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public RouteService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RouteDTO> GetRouteByIdAsync(int id)
        {
            var result = await _db.RouteRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<RouteDTO>(result);
            return null;
        }

        public async Task<IEnumerable<RouteDTO>> GetAllRoutesAsync()
        {
            IEnumerable<Route> result = await _db.RouteRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<RouteDTO>>(result);
            return null;
        }

        public async Task<RouteDTO> AddRouteAsync(RouteDTO routeDto)
        {
            Route route = _mapper.Map<Route>(routeDto);
            var result = await _db.RouteRepository.AddAsync(route);
            if (result != null) return _mapper.Map<RouteDTO>(result);
            return null;
        }

        public async Task<RouteDTO> EditRouteAsync(RouteDTO routeDto)
        {
            Route route = _mapper.Map<Route>(routeDto);
            var result = await _db.RouteRepository.UpdateAsync(route);
            if (result != null) return _mapper.Map<RouteDTO>(result);
            return null;
        }

        public async Task<bool> DeleteRouteAsync(int id)
        {
            return await _db.RouteRepository.DeleteAsync(id);
        }
    }
}