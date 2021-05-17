using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var result = await _db.ClientRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<UserDTO>(result);
            return null;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var result = await _db.ClientRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<UserDTO>>(result);
            return null;
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDto)
        {
            User car = _mapper.Map<User>(userDto);
            var result = await _db.ClientRepository.AddAsync(car);
            if (result != null) return _mapper.Map<UserDTO>(result);
            return null;
        }

        public async Task<UserDTO> EditUserAsync(UserDTO userDto)
        {
            User car = _mapper.Map<User>(userDto);
            var result = await _db.ClientRepository.UpdateAsync(car);
            if (result != null) return _mapper.Map<UserDTO>(result);
            return null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _db.ClientRepository.DeleteAsync(id);
        }
    }
}