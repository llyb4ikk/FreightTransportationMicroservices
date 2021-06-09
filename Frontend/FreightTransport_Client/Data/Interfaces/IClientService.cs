using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;
using FreightTransport_Client.Pages.Client;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface IClientService
    {
        Task<ClientModel> GetClientById(int id);
        Task<IEnumerable<ClientModel>> GetAllClients();
        Task<bool> AddClient(ClientModel clientModel);
        Task<bool> UpdateClient(ClientModel clientModel);
        Task<bool> DeleteClient(int id);
    }
}