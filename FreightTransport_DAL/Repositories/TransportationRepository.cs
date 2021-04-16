using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Repositories
{
    public class TransportationRepository : GenericRepository<Transportation>, ITransportationRepository
    {
        public TransportationRepository(FreightTransportDBContext context) : base(context)
        {

        }
    }
}