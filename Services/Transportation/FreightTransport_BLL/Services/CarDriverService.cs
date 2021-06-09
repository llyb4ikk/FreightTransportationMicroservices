using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class CarDriverService : ICarDriverService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public CarDriverService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CarDriverDTO> GetCarDriverByIdAsync(int id)
        {
            var result = await _db.CarDriverRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<CarDriverDTO>(result);
            return null;
        }

        public async Task<IEnumerable<CarDriverDTO>> GetAllCarDriversAsync()
        {
            IEnumerable<CarDriver> result = await _db.CarDriverRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<CarDriverDTO>>(result);
            return null;
        }

        public async Task<CarDriverDTO> AddCarDriverAsync(CarDriverDTO carDriverDto)
        {
            CarDriver carDriver = _mapper.Map<CarDriver>(carDriverDto);
            var result = await _db.CarDriverRepository.AddAsync(carDriver);
            if (result != null) return _mapper.Map<CarDriverDTO>(result);
            return null;
        }

        public async Task<CarDriverDTO> EditCarDriverAsync(CarDriverDTO carDriverDto)
        {
            CarDriver carDriver = _mapper.Map<CarDriver>(carDriverDto);
            var result = await _db.CarDriverRepository.UpdateAsync(carDriver);
            if (result != null) return _mapper.Map<CarDriverDTO>(result);
            return null;
        }

        public async Task<bool> DeleteCarDriverAsync(int id)
        {
            return await _db.CarDriverRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarDriverDTO>> GetAllFreeCarDrivers()
        {
            IEnumerable<CarDriver> result = await _db.CarDriverRepository.GetFreeCarDriversAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<CarDriverDTO>>(result);
            return null;
        }

    }
}