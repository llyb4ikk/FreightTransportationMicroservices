using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class RouteService : IRouteService
    {
        private readonly HttpClient _http;
        public RouteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<RouteModel> GetRouteById(int id)
        {
            return await _http.GetFromJsonAsync<RouteModel>($"Route/GetRouteById/{id}");
        }

        public async Task<RouteInfoModel> GetRouteInfoById(int id)
        {
            return await _http.GetFromJsonAsync<RouteInfoModel>($"Route/GetRouteInfoById/{id}");
        }

        public async Task<IEnumerable<RouteInfoModel>> GetAllRoutesInfo()
        {
            return await _http.GetFromJsonAsync<IEnumerable<RouteInfoModel>>("Route/GetAllRoutesInfo");
        }

        public async Task<IEnumerable<RouteModel>> GetAllRoutes()
        {
            return await _http.GetFromJsonAsync<IEnumerable<RouteModel>>("Route/GetAllRoutes");
        }

        public async Task<bool> AddRoute(RouteModel routeModel)
        {
            var response = await _http.PostAsJsonAsync("Route/AddRoute", routeModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> UpdateRoute(RouteModel routeModel)
        {
            var response = await _http.PutAsJsonAsync("Route/UpdateRoute", routeModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> DeleteRoute(int id)
        {
            var response = await _http.DeleteAsync($"Route/UpdateRoute/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}