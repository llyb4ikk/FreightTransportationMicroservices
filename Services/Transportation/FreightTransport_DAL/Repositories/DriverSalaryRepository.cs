using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport_DAL.Repositories
{
    public class DriverSalaryRepository: GenericRepository<DriverSalary>, IDriverSalaryRepository
    {
        private readonly FreightTransportDBContext _context;
        public DriverSalaryRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DriverSalary>> GetDriverSalaryInfo(int transportationId)
        {
            return await _context.DiverSalaries
                .Include(ds => ds.CarDriver)
                .Where(ds => ds.TransportationId == transportationId)
                .ToListAsync();
        }
    }
}