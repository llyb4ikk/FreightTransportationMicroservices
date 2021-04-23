using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class CargoService : ICargoService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public CargoService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CargoDTO> GetCargoByIdAsync(int id)
        {
            var result = await _db.CargoRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<CargoDTO>(result);
            return null;
        }

        public  async Task<IEnumerable<CargoDTO>> GetAllCargosAsync()
        {
            IEnumerable<Cargo> result = await _db.CargoRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<CargoDTO>>(result);
            return null;
        }

        public async Task<CargoDTO> AddCargoAsync(CargoDTO cargoDto)
        {
            Cargo cargo = _mapper.Map<Cargo>(cargoDto);
            var result = await _db.CargoRepository.AddAsync(cargo);
            if (result != null) return _mapper.Map<CargoDTO>(result);
            return null;
        }

        public async Task<CargoDTO> EditCargoAsync(CargoDTO cargoDto)
        {
            Cargo cargo = _mapper.Map<Cargo>(cargoDto);
            var result = await _db.CargoRepository.UpdateAsync(cargo);
            if (result != null) return _mapper.Map<CargoDTO>(result);
            return null;
        }

        public async Task<bool> DeleteCargoAsync(int id)
        {
            return await _db.CargoRepository.DeleteAsync(id);
        }
    }
}