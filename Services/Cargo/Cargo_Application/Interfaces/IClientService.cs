using System.Collections.Generic;
using System.Threading.Tasks;
using Cargo_Application.DTOs;

namespace Cargo_Application.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> GetClientById(int id);
        Task<IEnumerable<ClientDTO>> GetAllClients();

        Task<bool> CreateClient(ClientDTO clientDto);
        Task<ClientDTO> UpdateClient(ClientDTO clientDto);
        Task<bool> DeleteClient(int id);
    }
}