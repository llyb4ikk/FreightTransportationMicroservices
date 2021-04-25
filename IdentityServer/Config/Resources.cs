using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "freighttransportapi",
                    DisplayName = "Freight Transport API",
                    Description = "Allow the application to access Freight Transport API on your behalf",
                    Scopes = new List<string> { "freighttransportapi.read", "freighttransportapi.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("freighttransportapi.read", "Read Access to Freight Transport API"),
                new ApiScope("freighttransportapi.write", "Write Access to Freight Transport API")
            };
        }
    }
}