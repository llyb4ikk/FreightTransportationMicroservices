using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly IDriverSalaryService _driverSalaryService;
        private readonly ICarDriverService _carDriverService;
        public TransportationService(IUnitOfWork db, 
            IMapper mapper, 
            IDriverSalaryService driverSalaryService, 
            ICarDriverService carDriverService)
        {
            _db = db;
            _mapper = mapper;
            _driverSalaryService = driverSalaryService;
            _carDriverService = carDriverService;
        }

        public async Task<TransportationDTO> GetTransportationByIdAsync(int id)
        {
            var result = await _db.TransportationRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<TransportationDTO>(result);
            return null;
        }

        public async Task<IEnumerable<TransportationDTO>> GetAllTransportationsAsync()
        {
            IEnumerable<Transportation> result = await _db.TransportationRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<TransportationDTO>>(result);
            return null;
        }

        public async Task<TransportationDTO> AddTransportationAsync(TransportationDTO transportationDto)
        {
            Transportation transportation = _mapper.Map<Transportation>(transportationDto);

            var car = await _db.CarRepository.GetByIdAsync(transportation.CarId);
            car.Status = CarStatus.Busy;
            var updateCarResult = await _db.CarRepository.UpdateAsync(car);
            if (updateCarResult == null) return null;

            transportation.Cost = GetCostOfTransportation(transportation.Distance, car.FuelConsumption);

            var result = await _db.TransportationRepository.AddAsync(transportation);
            if (result != null) return _mapper.Map<TransportationDTO>(result);
            return null;
        }

        public async Task<TransportationDTO> EditTransportationAsync(TransportationDTO transportationDto)
        {
            Transportation transportation = _mapper.Map<Transportation>(transportationDto);
            var result = await _db.TransportationRepository.UpdateAsync(transportation);
            if (result != null) return _mapper.Map<TransportationDTO>(result);
            return null;
        }

        public async Task<bool> DeleteTransportationAsync(int id)
        {
            return await _db.TransportationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TransportationTableDTO>> GetAllTransportationsTable()
        {
            var result = await _db.TransportationRepository.GetAllWithCities();
            if (result != null)
                return _mapper.Map<IEnumerable<TransportationTableDTO>>(result);
            return null;
        }

        public async Task<TransportationDetailsDTO> GetTransportationDetailsById(int id)
        {
            var result = await _db.TransportationRepository.GetAllWithCitiesById(id);
            if (result != null)
                return _mapper.Map<TransportationDetailsDTO>(result);
            return null;
        }

        public async Task<bool> NextStageAsync(int transportationId)
        {
            var transportation = await _db.TransportationRepository.GetByIdAsync(transportationId);
            if (transportation == null) return false;

            if (transportation.Status != TransportationStatus.Done)
            {
                transportation.Status++;

                if (transportation.Status == TransportationStatus.Done)
                {
                    var car = await _db.CarRepository.GetByIdAsync(transportation.CarId);
                    car.Status = CarStatus.Free;
                    var updateCarResult = await _db.CarRepository.UpdateAsync(car);
                    if (updateCarResult == null) return false;

                    var carDrivers = await _db.CarDriverRepository.GetCarDriversByTransportationId(transportation.Id);
                    carDrivers.ForAll(c => c.Status = CarDriverStatus.Free);
                    foreach (var carDriver in carDrivers)
                    {
                        await _db.CarDriverRepository.UpdateAsync(carDriver);
                    }
                }
            }
            
            var result = await _db.TransportationRepository.UpdateAsync(transportation);
            if (result != null) return true;
            return false;
        }

        public async Task<bool> SetDriversToTransportyation(int transportationId, IEnumerable<int> carDriversIds)
        {
            var transportation = await _db.TransportationRepository.GetByIdAsync(transportationId);
            if (transportation == null) return false;

            if (carDriversIds.Count() < 1 && carDriversIds.Count() > 2) return false;
            foreach (var carDriverId in carDriversIds)
            {
                var carDriver = await _db.CarDriverRepository.GetByIdAsync(carDriverId);
                carDriver.Status = CarDriverStatus.Busy;
                var updateCaraDriverResult = await _db.CarDriverRepository.UpdateAsync(carDriver);
                if (updateCaraDriverResult == null) return false;

                var driverSalary = new DriverSalaryDTO
                    {
                        CarDriverId = carDriverId,
                        TransportationId = transportationId,
                        Salary = GetSalary(transportation.Distance, carDriver.Experience, carDriversIds.Count())
                    };
                 var addDriverSalaryResult = await _driverSalaryService.AddDriverSalaryAsync(driverSalary);
                 if (addDriverSalaryResult == null) return false;
            }

            return true;
        }

        public double GetSalary(double transportationDistance, int carDriverExperiance, int countOfDrivers)
        {
            var salary = (transportationDistance + 200 + (carDriverExperiance * 100)) * ((countOfDrivers == 1)? 1.5 : 1);
            return salary;
        }

        public int GetCostOfTransportation(double distance, float carFuelConsumption)
        {
            return (int) (distance * 3 * (carFuelConsumption / 100) * 25);
        }
    }
}