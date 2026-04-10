using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // ✅ Simple hardcoded login
            if (username == "admin" && password == "123")
            {
                // ✅ Claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };

                // ✅ Get key from appsettings.json
                var keyString = _config["Jwt:Key"];

                if (string.IsNullOrEmpty(keyString))
                {
                    return BadRequest("JWT Key is missing in configuration");
                }

                // ✅ Convert key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyVeryStrongSecretKeyFor JWTAuthentication12345"));

                // ✅ Create credentials
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // ✅ Create token
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                // ✅ Convert token to string
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // ✅ Return response
                return Ok(new
                {
                    token = tokenString
                });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}