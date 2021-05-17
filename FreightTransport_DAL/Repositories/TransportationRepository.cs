using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport_DAL.Repositories
{
    public class TransportationRepository : GenericRepository<Transportation>, ITransportationRepository
    {
        private readonly FreightTransportDBContext _context;
        public TransportationRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transportation>> GetAllWithCities()
        {
            return await _context.Transportations
                .Include(c => c.StartCity)
                .Include(c => c.DestinationCity)
                .ToListAsync();
        }
        public async Task<Transportation> GetAllWithCitiesById(int id)
        {
            return await _context.Transportations
                .Include(c => c.StartCity)
                .Include(c => c.DestinationCity)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}