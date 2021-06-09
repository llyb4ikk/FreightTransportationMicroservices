using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;
        public ClientService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            return await _http.GetFromJsonAsync<ClientModel>("Client/GetClientById/" + id);
        }

        public async Task<IEnumerable<ClientModel>> GetAllClients()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ClientModel>>("Client/GetAllClients/");
        }

        public async Task<bool> AddClient(ClientModel clientModel)
        {
            var response = await _http.PostAsJsonAsync("Client/AddClient", clientModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> UpdateClient(ClientModel clientModel)
        {
            var response = await _http.PutAsJsonAsync("Client/UpdateClient", clientModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var response = await _http.DeleteAsync($"Client/UpdateClient/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}