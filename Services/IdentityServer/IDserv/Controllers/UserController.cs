using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using IDserv.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace IDserv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(Loginmodel logIn)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(logIn.Login);

            // validate username/password using ASP.NET Identity 
            if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, logIn.Password, false)) == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                var client = new HttpClient();
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = "https://localhost:44366/connect/token",
                    ClientId = "MainClient",
                    Scope = "freighttransportapi.read",
                    ClientSecret = "Secretpaswd"
                });

                if (!tokenResponse.IsError)
                {
                    return Ok(tokenResponse.AccessToken);
                }
                else
                {
                    return Ok(tokenResponse.Error);
                }
            }
            else return BadRequest("Invalid username or password");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(IdentityUser user, string password)
        {
            var result = await _signInManager.UserManager.CreateAsync(user, password);
            return Ok(result);

            //// validate username/password using ASP.NET Identity 
            //if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, logIn.Password, false)) == Microsoft.AspNetCore.Identity.SignInResult.Success)
            //{
            //    var client = new HttpClient();
            //    var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //    {
            //        Address = "https://localhost:44366/connect/token",
            //        ClientId = "MainClient",
            //        Scope = "freighttransportapi.read",
            //        ClientSecret = "Secretpaswd"
            //    });

            //    if (!tokenResponse.IsError)
            //    {
            //        return Ok(tokenResponse.AccessToken);
            //    }
            //    else
            //    {
            //        return Ok(tokenResponse.Error);
            //    }
            //}
            //else return BadRequest("Invalid username or password");
        }
    }
}