using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class DriverSalaryService : IDriverSalaryService
    {

        private readonly HttpClient _http;
        public DriverSalaryService(HttpClient http)
        {
            _http = http;
        }


        public Task<DriverSalaryModel> GetDriverSalaryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DriverSalaryModel>> GetAllDriverSalaryModels()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddDriverSalary(DriverSalaryModel driverSalaryModel)
        {
            var response = await _http.PostAsJsonAsync("DriverSalary/AddDriverSalary", driverSalaryModel);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public Task<bool> UpdateDriverSalary(DriverSalaryModel driverSalaryModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteDriverSalary(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<DriverSalaryInfoModel>> GetDriverSalariesInformationByTransportation(int transportationId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<DriverSalaryInfoModel>>(
                $"DriverSalary/GetDriverSalariesInformationByTransportation/{transportationId}");
        }
    }
}