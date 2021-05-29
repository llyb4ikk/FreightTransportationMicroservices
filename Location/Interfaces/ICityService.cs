using System.Collections.Generic;
using System.Threading.Tasks;
using Location.Entities;
using Location.Enums;

namespace Location.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityById(string id);
        Task<IEnumerable<City>> GetCitiesByRegion(Region region);
    }
}