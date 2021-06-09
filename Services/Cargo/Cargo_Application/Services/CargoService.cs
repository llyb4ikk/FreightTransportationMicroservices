using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using Cargo_Infrastructure.Interfaces;

namespace Cargo_Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CargoService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CargoDTO> GetCargoById(int id)
        {
            var result = await _uow.CargoRepository.GetByIdAsync(id);
            return _mapper.Map<CargoDTO>(result);
        }

        public async Task<IEnumerable<CargoDTO>> GetAllCargos()
        {
            var result = await _uow.CargoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CargoDTO>>(result);
        }

        public async Task<IEnumerable<CargoDTO>> GetCargosByTransportation(int transportationId)
        {
            var result = await _uow.CargoRepository.GetByTransprtationId(transportationId);
            return _mapper.Map<IEnumerable<CargoDTO>>(result);
        }

        public Task<IEnumerable<CargoDTO>> GetCargosByOwner(int ownerId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CargoInformationDTO>> GetCargosInformationByTransportation(int transportationId)
        {
            var result = await _uow.CargoRepository.GetCargosByTransportationId(transportationId);
            return _mapper.Map<IEnumerable<CargoInformationDTO>>(result);
        }

        public async Task<bool> RemoveCargoFromTransportation(int cargoId)
        {
            var cargo = await _uow.CargoRepository.GetByIdAsync(cargoId);

            cargo.TransportationId = 0;

            var result = await _uow.CargoRepository.UpdateAsync(cargo);
            return result;
        }

        public async Task<bool> SetCargoTransportation(int cargoId, int? transportationId)
        {
            var cargo = await _uow.CargoRepository.GetByIdAsync(cargoId);

            cargo.TransportationId = transportationId;

            var result = await _uow.CargoRepository.UpdateAsync(cargo);
            return result;
        }

        public async Task<IEnumerable<CargoInformationDTO>> GetAllCargosInformation()
        {
            return _mapper.Map<IEnumerable<CargoInformationDTO>>(await _uow.CargoRepository.GetAllCagosInformation());
        }

        public async Task<bool> CreateCargo(CargoDTO cargoDto)
        {
            var cargo = _mapper.Map<Cargo_Domain.Entities.Cargo>(cargoDto);
            var result = await _uow.CargoRepository.AddAsync(cargo);
            return result;
        }

        public Task<CargoDTO> UpdateCargo(CargoDTO cargoDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCargo(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}