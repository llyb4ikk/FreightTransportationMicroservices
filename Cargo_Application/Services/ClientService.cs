using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using Cargo_Domain.Entities;
using Cargo_Infrastructure.Interfaces;

namespace Cargo_Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ClientService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<ClientDTO> GetClientById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var result = await _uow.ClientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(result);
        }

        public async Task<bool> CreateClient(ClientDTO clientDto)
        {
            var client = _mapper.Map<Cargo_Domain.Entities.Client>(clientDto);
            var result = await _uow.ClientRepository.AddAsync(client);
            return result;
        }

        public Task<ClientDTO> UpdateClient(ClientDTO clientDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteClient(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}