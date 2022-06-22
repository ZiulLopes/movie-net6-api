using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movie.Core.Config;
using Movie.Core.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movie.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private readonly JwtBearerTokenSettings _jwtConfig;


        public LoginController(IConfiguration configuration, ILogger<LoginController> logger, JwtBearerTokenSettings jwtConfig)
        {
            _configuration = configuration;
            _logger = logger;
            _jwtConfig = jwtConfig;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation($"{loginRequest.Email} is getting Token");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, loginRequest.Email),
                    //new Claim("EmployeeCode", "1")
                }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtConfig.ExpiryTimeInSeconds),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer,
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.Run(() => Ok(new
            {
                token = tokenHandler.WriteToken(token),
            }));
        }
    }
}
