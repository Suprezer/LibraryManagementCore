using LibraryManagement.Application.Common.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryManagementAPI.API.Controllers
{
    public class TokensController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokensController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/api/Tokens")]
        [HttpPost]
        // Generate and return a JWT
        public IActionResult Create(string username, string password, string grant_Type)
        {
            IActionResult foundToken;
            bool hasInput = ((!string.IsNullOrEmpty(username)) && (!string.IsNullOrEmpty(password)));

            // We're only returning a JWT if the credentials are correct
            SecurityHelper secUtil = new SecurityHelper(_configuration);
            if ((hasInput && secUtil.IsValidUsernameAndPassword(username, password)))
            {
                RoleEnum role = secUtil.GetRoleEnum(grant_Type);
                string jwtToken = GenerateToken(username, role);
                foundToken = new ObjectResult(jwtToken);
            }
            else
            {
                foundToken = BadRequest();
            }
            return foundToken;
        }

        private string GenerateToken(string username, RoleEnum authorRole)
        {
            string jwtString = null;
            SecurityHelper secUtil = new SecurityHelper(_configuration);
            SymmetricSecurityKey? signingKey = secUtil.GetSecurityKey();

            SigningCredentials credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, authorRole.ToString())
            };

            // Hack: We're setting the expiration time to 10 minutes
            int durationInMinutes = 10;
            DateTime expireAt = DateTime.Now.AddMinutes(durationInMinutes);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:7222",
                audience: "https://localhost:7222",
                claims: claims,
                expires: expireAt,
                signingCredentials: credentials
            );

            jwtString = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtString;
        }
    }
}