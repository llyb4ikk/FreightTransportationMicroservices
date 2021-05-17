using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public CarService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            var result = await _db.CarRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<CarDTO>(result);
            return null;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            IEnumerable<Car> result = await _db.CarRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<CarDTO>>(result);
            return null;
        }

        public async Task<CarDTO> AddCarAsync(CarDTO carDto)
        {
            Car car = _mapper.Map<Car>(carDto);
            var result = await _db.CarRepository.AddAsync(car);
            if (result != null) return _mapper.Map<CarDTO>(result);
            return null;
        }

        public async Task<CarDTO> EditCarAsync(CarDTO carDto)
        {
            Car car = _mapper.Map<Car>(carDto);
            var result = await _db.CarRepository.UpdateAsync(car);
            if (result != null) return _mapper.Map<CarDTO>(result);
            return null;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            return await _db.CarRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarDTO>> GetFreeCarsOfSelectedType(CarType carType)
        {
            var result = await _db.CarRepository.GetFreeCarsOfCartype(carType);
            if (result != null) return _mapper.Map<IEnumerable<CarDTO>>(result);
            return null;
        }
    }
}