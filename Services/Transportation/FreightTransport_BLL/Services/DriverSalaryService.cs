using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;

namespace FreightTransport_BLL.Services
{
    public class DriverSalaryService : IDriverSalaryService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public DriverSalaryService(IUnitOfWork db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }

        public async Task<DriverSalaryDTO> GetDriverSalaryByIdAsync(int id)
        {
            var result = await _db.DriverSalaryRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<DriverSalaryDTO>(result);
            return null;
        }

        public async Task<IEnumerable<DriverSalaryDTO>> GetAllDriverSalarysAsync()
        {
            var result = await _db.DriverSalaryRepository.GetAllAsync();
            if (result != null)
                return _mapper.Map<IEnumerable<DriverSalaryDTO>>(result);
            return null;
        }

        public async Task<DriverSalaryDTO> AddDriverSalaryAsync(DriverSalaryDTO carDto)
        {
            DriverSalary car = _mapper.Map<DriverSalary>(carDto);
            var result = await _db.DriverSalaryRepository.AddAsync(car);
            if (result != null) return _mapper.Map<DriverSalaryDTO>(result);
            return null;
        }

        public async Task<DriverSalaryDTO> EditDriverSalaryAsync(DriverSalaryDTO carDto)
        {
            DriverSalary car = _mapper.Map<DriverSalary>(carDto);
            var result = await _db.DriverSalaryRepository.UpdateAsync(car);
            if (result != null) return _mapper.Map<DriverSalaryDTO>(result);
            return null;
        }

        public async Task<bool> DeleteDriverSalaryAsync(int id)
        {
            return await _db.DriverSalaryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DriverSalaryInformationDTO>> GetDriverSalariesBytransportationAsync(int transportationId)
        {
            return _mapper.Map<IEnumerable<DriverSalaryInformationDTO>>(await _db.DriverSalaryRepository.GetDriverSalaryInfo(transportationId));
        }
    }
}