using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;
using FreightTransport_DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport_DAL.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly FreightTransportDBContext _context;

        public CityRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesByRegion(Region region)
        {
            return await _context.Set<City>().Where(c => c.Region == region).ToListAsync();
        }
    }
}