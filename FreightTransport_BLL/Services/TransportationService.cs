using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
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
    }
}