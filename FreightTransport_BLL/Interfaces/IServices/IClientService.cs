using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface IClientService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> AddUserAsync(UserDTO userDto);
        Task<UserDTO> EditUserAsync(UserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}