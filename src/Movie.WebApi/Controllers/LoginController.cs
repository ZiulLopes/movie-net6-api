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
        public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, loginRequest.Email),
                }),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.Run(() => Ok(new
            {
                token = tokenHandler.WriteToken(token),
            }));
        }
    }
}
