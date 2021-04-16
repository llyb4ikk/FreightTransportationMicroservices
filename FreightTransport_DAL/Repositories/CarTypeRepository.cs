using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Repositories
{
    public class CarTypeRepository : GenericRepository<CarType>, ICarTypeRepository
    {
        public CarTypeRepository(FreightTransportDBContext context) : base(context)
        {

        }
    }
}