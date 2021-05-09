using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Enums;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityModel>> GetCitiesbyRegion(Region region);
        Task<CityModel> GetCityById(int id);
    }
}