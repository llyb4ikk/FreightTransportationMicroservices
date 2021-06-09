using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "MainClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("Secretpaswd".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "freighttransportapi.read", 
                        "freighttransportapi.write"
                    }
                }
            };
        }
    }
}