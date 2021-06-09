using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using FreightTransport_Client.Data.Interfaces;
using FreightTransport_Client.Data.Models;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.VisualBasic;

namespace FreightTransport_Client.Data.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        //public async Task<TokenResponse> Login()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:44366/");

        //    var token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //    {
        //        Address = discoveryDocument.TokenEndpoint,

        //        ClientId = "client_id",
        //        ClientSecret = "client_secret",

        //        Scope = "freighttransportapi"
        //    });
        //    return token;
        //}

        //public async Task<JWTModel> LoginAsync(UserModel user)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("https://localhost:44366/connect/token", );
        //    if (response != null) return response;
        //    return null;
        //}

        //public async Task<UserModel> GetUserByTokenAsync(JWTModel token)
        //{
        //    var response = await _httpClient.GetFromJsonAsync<UserModel>("", );
        //    if (response != null) return response;
        //    return null;
        //}
    }
}