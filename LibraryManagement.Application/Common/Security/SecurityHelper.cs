using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagement.Application.Common.Security
{
    public class SecurityHelper
    {
        private readonly IConfiguration _configuration;

        public SecurityHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SymmetricSecurityKey? GetSecurityKey()
        {
            SymmetricSecurityKey? SIGNING_KEY = null;
            string? SECRET_KEY = _configuration["SECRET_KEY"];
            if (!string.IsNullOrEmpty(SECRET_KEY))
            {
                SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            }
            return SIGNING_KEY;
        }

        public bool IsValidUsernameAndPassword(string username, string password)
        {
            bool credentialsOk = false;

            string? allowedUsername = null;
            string? allowedPassword = null;

            if (username == _configuration["AllowWebApp:Username"])
            {
                allowedUsername = _configuration["AllowWebApp:Username"];
                allowedPassword = _configuration["AllowWebApp:Password"];
            }

            if (allowedUsername != null && allowedPassword != null)
            {
                credentialsOk = (username.Equals(allowedUsername) && password.Equals(allowedPassword));
            }
            return credentialsOk;
        }

        public RoleEnum GetRoleEnum(string roleStr)
        {
            RoleEnum foundRoleEnum;
            bool wasSuccesful = Enum.TryParse(roleStr, out foundRoleEnum);

            if (!wasSuccesful)
            {
                foundRoleEnum = RoleEnum.User;
            }

            return foundRoleEnum;
        }
    }
}