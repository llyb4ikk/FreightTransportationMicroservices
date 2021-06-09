using Cargo_Domain.Entities;
using Cargo_Infrastructure.Interfaces;
using Cargo_Infrastructure.Interfaces.IRepositories;

namespace Cargo_Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(IConnectionFactory connectionFactory) : base(connectionFactory, "Users")
        {

        }
    }
}