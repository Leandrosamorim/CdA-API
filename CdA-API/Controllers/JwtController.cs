
using Domain.Interfaces.Services;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CdA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserServices _userServices;

        public JwtController(IConfiguration configuration, IUserServices userServices)
        {
            _configuration = configuration;
            _userServices = userServices;
        }


        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user == null)
                return BadRequest("Invalid User");
            else
            {
                var userData = await GetUser(user.UserName, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.UserName ),
                        new Claim("Password", user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                    return BadRequest("User not found");
            }
        }
        [HttpGet]
        public async Task<User> GetUser(string userName, string password)
        {
            return await _userServices.GetUser(userName, password);
        }

        [HttpPost("add")]
        public async Task<User> Add(User user)
        {
            return await _userServices.Add(user);
        }

    }
}
