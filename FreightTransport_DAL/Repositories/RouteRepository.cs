using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport_DAL.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        private readonly FreightTransportDBContext _context;
        private readonly IMapper _mapper;
        public RouteRepository(FreightTransportDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Route> GetRouteInfoById(int id)
        {
            return await _context.Routes
                .Include(c => c.StartCity)
                .Include(c => c.DestinationCity)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Route>> GetAllRoutesInfo()
        {
            return await _context.Routes
                    .Include(c => c.StartCity)
                    .Include(c => c.DestinationCity)
                    .ToListAsync();
        }
    }
}