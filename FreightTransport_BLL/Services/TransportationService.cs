using System;
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
    public class TransportationService : ITransportationService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public TransportationService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
            await _db.CarRepository.UpdateAsync(car);

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

        public Task<IEnumerable<TransportationTableDTO>> GetTranspotationsTableBy(Func<IEnumerable<TransportationTableDTO>> f)
        {
            throw new NotImplementedException();
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

            if(transportation.Status != TransportationStatus.Done)
                transportation.Status++;

            var result = await _db.TransportationRepository.UpdateAsync(transportation);
            if (result != null) return true;
            return false;
        }
    }
}