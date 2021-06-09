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
            return await _http.GetFromJsonAsync<TransportationInfoModel>(
                $"Transportation/GetTransportationInfoById/{id}");
        }

        public async Task<IEnumerable<TransportationTableModel>> GetAllTransportationsTable()
        {
            return await _http.GetFromJsonAsync<IEnumerable<TransportationTableModel>>(
                $"Transportation/GetAllTransportationsTable");
        }

        public async Task<TransportationModel> AddTransportation(TransportationModel transportationModel)
        {
            var response = await _http.PostAsJsonAsync("Transportation/AddTransportation", transportationModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadFromJsonAsync<TransportationModel>();
            return null;
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

        public async Task<TransportationInfoModel> GetTransportationDetailsById(int id)
        {
            var response =
             await _http.GetFromJsonAsync<TransportationInfoModel>(
                $"Transportation/GettransportationDetailsById/{id}");
            return response;
        }

        public async Task<bool> NextStage(int transportationId)
        {
            var response =
                await _http.GetFromJsonAsync<bool>(
                    $"Transportation/NextStage/{transportationId}");
            return response;
        }
    }
}