using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Enums;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class CityService : ICityService
    {
        private readonly HttpClient _http;
        public CityService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<CityModel>> GetCitiesbyRegion(Region region)
        {
            //var response = await _http.GetAsync($"City/GetCitiesByRoute/{region}");

            //var responseContent = await response.Content.ReadAsStreamAsync();

            //var ret =await JsonSerializer.DeserializeAsync<List<CityModel>>
            //(responseContent,
            //    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            //return ret;

            return await _http.GetFromJsonAsync<IEnumerable<CityModel>>($"City/GetCitiesByRoute/{region}");
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await _http.GetFromJsonAsync<CityModel>($"City/GetCityById/{id}");
        }
    }
}