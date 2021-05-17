using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IDserv.DBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer
{
    public class MainConfig
    {
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "123",
                    Username = "admin",
                    Password = "passwd123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Liubomyr Tymchuk"),
                        new Claim(JwtClaimTypes.GivenName, "Lybchik"),
                        new Claim(JwtClaimTypes.FamilyName, "Tymchuk"),
                        new Claim(JwtClaimTypes.Email, "some@mail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "admin"),
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
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
                    ApiSecrets = new List<Secret> {new Secret("SecretPasswd".Sha256())},
                    //UserClaims = new List<string> {"role"}
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

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "MainClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = 
                    {
                        new Secret("Secretpaswd".Sha256())
                    },
                    AllowedScopes = 
                    {
                        "freighttransportapi.read",
                        "freighttransportapi.write"
                    }
                }
            };
        }

        

        public static void Init(IServiceProvider provider, bool useInMemoryStores)
        {
            if (!useInMemoryStores)
            {
                provider.GetRequiredService<DBContext>().Database.Migrate();
                provider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                provider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
            }
            InitializeIdentityServer(provider);
        }

        private static void InitializeIdentityServer(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ConfigurationDbContext>();
            if (!context.Clients.Any())
            {
                foreach (var client in GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var scope in GetApiScopes())
                {
                    context.ApiScopes.Add(scope.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in GetIdentityResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in GetApiResources())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }
    }
}