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
    public class CarDriverRepository : GenericRepository<CarDriver>, ICarDriverRepository
    {
        private readonly FreightTransportDBContext _context;
        public CarDriverRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CarDriver>> GetFreeCarDriversAsync()
        {
            return await _context.CarDrivers.Where(cd => cd.Status == CarDriverStatus.Free).ToListAsync();
        }

        public async Task<IEnumerable<CarDriver>> GetCarDriversByTransportationId(int transportationId)
        {
            var driverSalaries =  await _context.DiverSalaries
                .Where(ds => ds.TransportationId == transportationId)
                .Include(cd => cd.CarDriver)
                .ToListAsync();

            return  driverSalaries.Select(ds => ds.CarDriver).ToList();
        }
    }
}