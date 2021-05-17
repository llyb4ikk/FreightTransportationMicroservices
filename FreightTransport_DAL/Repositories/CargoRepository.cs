using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport_DAL.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly FreightTransportDBContext _context;

        public CargoRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Cargo>> GetAllCargosWithOwnersByTransportationId(int id)
        {
            return await _context.Cargos
                .Include(c => c.Owner)
                .Where(c => c.TransportationId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cargo>> GetAllCargosWithOwners()
        {
            return await _context.Cargos
                .Include(c => c.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cargo>> GetAllCargosWithOwnersWithoutTransportation()
        {
            return await _context.Cargos
                .Include(c => c.Owner)
                .Where(c => c.TransportationId == null)
                .ToListAsync();
        }
    }
}