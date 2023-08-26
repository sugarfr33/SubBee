using Microsoft.IdentityModel.Tokens;
using SubBee.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SubBee.Services.Token
{
    public class TokenService : ITokenService
    {
        public string CreateToken(UserModel user, byte[] secretKeyToken)
        {
            var claims = new List<Claim>()
            {
                new Claim("Username", user.UserName)
            };

            var key = new SymmetricSecurityKey(secretKeyToken);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
