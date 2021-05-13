using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly HttpClient _http;
        public TransportationService(HttpClient http)
        {
            _http = http;
        }


        public async Task<TransportationInfoModel> GetTransportationInfoById(int id)
        {
            return await _http.GetFromJsonAsync<TransportationInfoModel>($"Transportation/GetTransportationInfoById/{id}");
        }

        public async Task<IEnumerable<TransportationTableModel>> GetAllTransportationsTable()
        {
            return await _http.GetFromJsonAsync<IEnumerable<TransportationTableModel>>($"Transportation/GetAllTransportationTables");
        }

        public async Task<bool> AddTransportation(TransportationModel transportationModel)
        {
            var response = await _http.PostAsJsonAsync("Transportation/AddTransportation", transportationModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> UpdateTransportation(TransportationModel transportationModel)
        {
            var response = await _http.PutAsJsonAsync("Transportation/AddTransportation", transportationModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> DeleteTransportation(int id)
        {
            var response = await _http.DeleteAsync($"Transportation/DeleteTransportation/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}