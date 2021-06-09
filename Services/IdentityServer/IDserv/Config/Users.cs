using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Users
    {
        public static List<TestUser> Get()
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
    }
}