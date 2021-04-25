using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreightTransport_Client.Data.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient http;
        public CarService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<CarModel> GetCarById(int id)
        {
            return await http.GetFromJsonAsync<CarModel>("Car/GetCarById/" + id);
        }

        public async Task<IEnumerable<CarModel>> GetAllCars()
        {
            var response = await http.GetAsync("Car/GetAllCars");

            var responseContent = await response.Content.ReadAsStreamAsync();

            return await System.Text.Json.JsonSerializer.DeserializeAsync<List<CarModel>>
            (responseContent,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task<CarModel> AddCar(CarModel car)
        {
            var response = await http.PostAsJsonAsync("Car/AddCar", car);
            return await response.Content.ReadFromJsonAsync<CarModel>();
        }
    }
}
