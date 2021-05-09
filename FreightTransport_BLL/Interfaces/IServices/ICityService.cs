using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface ICityService
    {
        Task<CityDTO> GetCityByIdAsync(int id);
        //Task<CityDTO> GetCityByName(string name);
        Task<IEnumerable<CityDTO>> GetCitiesByRegion(Region region);
        Task<CityDTO> AddCityAsync(CityDTO cityDto);

    }
}