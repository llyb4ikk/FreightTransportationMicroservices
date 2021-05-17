using FreightTransport_DAL.DBContext;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Repositories
{
    public class ClientRepository : GenericRepository<User>, IClientRepository
    {
        private readonly FreightTransportDBContext _context;
        public ClientRepository(FreightTransportDBContext context) : base(context)
        {
            _context = context;
        }

    }
}