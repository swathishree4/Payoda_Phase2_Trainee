using API_MINI_MAIN.Model;
using Apiproject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_MINI_MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly AppDbContext _con;

        public TokenController(IConfiguration configuration, AppDbContext con)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _con = con;
        }

        [HttpPost]
        public string GenerateToken(User user)
        {
            string token = string.Empty;
            string requiredRole = user.Role;
          
            if (user.Role == "Admin")
            {
                if (ValidateUser(user.email, user.Password, requiredRole))
                {
                    token = GenerateAdminToken(user);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
               

                if (ValidateUser(user.email, user.Password, requiredRole))
                {
                    var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                    new Claim(ClaimTypes.Role, user.Role!)
                };

                    var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        SigningCredentials = cred,
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddMinutes(2)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createToken = tokenHandler.CreateToken(tokenDescription);
                    token = tokenHandler.WriteToken(createToken);
                }
                else
                {
                    return string.Empty;
                }
            }

            return token;
        }

      
        private string GenerateAdminToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email,user.email), 
            new Claim(ClaimTypes.Role, "Admin")
        };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                SigningCredentials = cred,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(2)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(createToken);
        }

     
        private bool ValidateUser(string email, string password, string requiredRole)
        {
            var user = _con.users.FirstOrDefault(u => u.email == email && u.Password == password);
            return user != null && user.Role == requiredRole;
        }
    }
}
