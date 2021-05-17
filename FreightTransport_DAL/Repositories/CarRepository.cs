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
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly FreightTransportDBContext _context;
        public CarRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetFreeCarsOfCartype(CarType carType)
        {
            return await _context.Cars.Where(c => c.CarType == carType).Where(c => c.Status == CarStatus.Free)
                .ToListAsync();
        }
    }
}