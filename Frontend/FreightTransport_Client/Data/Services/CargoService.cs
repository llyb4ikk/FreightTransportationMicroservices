using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class CargoService : ICargoService
    {
        private readonly HttpClient _http;
        public CargoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CargoModel> GetCargoById(int id)
        {
            return await _http.GetFromJsonAsync<CargoModel>("Cargo/GetCargoById/" + id);
        }

        public async Task<IEnumerable<CargoTableModel>> GetAllCargoTableModels()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CargoTableModel>>("Cargo/GetAllCargosWithOwner");
        }

        public async Task<bool> AddCargo(CargoModel cargoModel)
        {
            var response = await _http.PostAsJsonAsync("Cargo/AddCargo", cargoModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> UpdateCargo(CargoModel cargoModel)
        {
            var response = await _http.PutAsJsonAsync("Cargo/UpdateCargo", cargoModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> DeleteCargo(int id)
        {
            var response = await _http.DeleteAsync($"Cargo/DeleteCargo/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<IEnumerable<CargoTableModel>> GetAllCargoModelsWithoutTransportation()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CargoTableModel>>("Cargo/GetAllCargosWithOwnersWithputTransportation");
        }

        public async Task<IEnumerable<CargoTableModel>> GetAllCargoModelsBytransportationId(int id)
        {
            var response = await _http.GetFromJsonAsync<IEnumerable<CargoTableModel>> ($"Cargo/GetAllCargosWithOwnersByTransportationId/{id}");
            return response;
        }

        public async Task<bool> RemoveCargoFromTransportation(int cargoId)
        {
            var response = await _http.PutAsJsonAsync($"Cargo/RemoveCargoToTransportation", cargoId);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> AddCargoToTransportation(int cargoId, int transportationId)
        {
            var response = await _http.PutAsJsonAsync($"Cargo/AddCargoToTransportation/{transportationId}", cargoId);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}