using System.Threading.Tasks;
using IdentityModel.Client;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}