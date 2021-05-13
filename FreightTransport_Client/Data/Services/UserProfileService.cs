using System.Net.Http;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Services
{
    public class UserProfileService
    {
        private readonly HttpClient _httpClient;

        public UserProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<UserProfileModel> GetUserProfileById();
    }
}