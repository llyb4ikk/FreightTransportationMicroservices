using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreightTransport_Client.Data.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _http;
        public CarService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CarModel> GetCarById(int id)
        {
            return await _http.GetFromJsonAsync<CarModel>("Car/GetCarById/" + id);
        }

        public async Task<IEnumerable<CarModel>> GetAllCars()
        {

            var response = await _http.GetAsync("Car/GetAllCars");

            var responseContent = await response.Content.ReadAsStreamAsync();

            return await System.Text.Json.JsonSerializer.DeserializeAsync<List<CarModel>>
            (responseContent,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task<bool> AddCar(CarModel car)
        {
            var response = await _http.PostAsJsonAsync("Car/AddCar", car);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
            
        }

        public async Task<bool> UpdateCar(CarModel car)
        {
            var response = await _http.PutAsJsonAsync("Car/UpdateCar", car);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var response = await _http.DeleteAsync($"Car/DeleteCar/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}
