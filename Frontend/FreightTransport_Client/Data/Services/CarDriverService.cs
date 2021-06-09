using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class CarDriverService : ICarDriverService
    {
        private readonly HttpClient _http;
        public CarDriverService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CarDriverModel> GetCarDriverById(int id)
        {
            return await _http.GetFromJsonAsync<CarDriverModel>($"CarDriver/{id}");
        }

        public async Task<IEnumerable<CarDriverModel>> GetAllCarDrivers()
        {
            var response = await _http.GetAsync("CarDriver");

            var responseContent = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<List<CarDriverModel>>
            (responseContent,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task<bool> AddCarDriver(CarDriverModel carDriver)
        {
            var response = await _http.PostAsJsonAsync("CarDriver", carDriver);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> UpdateCarDriver(CarDriverModel carDriver)
        {
            var response = await _http.PutAsJsonAsync("CarDriver", carDriver);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public  async Task<bool> DeleteCarDriver(int id)
        {
            var response = await _http.DeleteAsync($"CarDriver/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<IEnumerable<CarDriverModel>> GetAllFreeCarDrivers()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CarDriverModel>>("CarDriver/FreeDrivers");
        }
    }
}