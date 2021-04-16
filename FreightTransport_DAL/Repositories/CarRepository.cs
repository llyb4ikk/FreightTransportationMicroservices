using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(FreightTransportDBContext context) : base(context)
        {

        }
    }
}