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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }

        public async Task<CityDTO> GetCityByIdAsync(int id)
        {
            var result = await _db.CityRepository.GetByIdAsync(id);
            if (result != null)
                return _mapper.Map<CityDTO>(result);
            return null;
        }

        public async Task<IEnumerable<CityDTO>> GetCitiesByRegion(Region region)
        {
            IEnumerable<City> result = await _db.CityRepository.GetCitiesByRegion(region);
            if (result != null)
                return _mapper.Map<IEnumerable<CityDTO>>(result);
            return null;
        }

        public async Task<CityDTO> AddCityAsync(CityDTO cityDto)
        {
            City city = _mapper.Map<City>(cityDto);
            var result = await _db.CityRepository.AddAsync(city);
            if (result != null) 
                return _mapper.Map<CityDTO>(result);
            return null;
        }
    }
}