using Microsoft.IdentityModel.Tokens;
using SalesReporting.Data;
using SalesReporting.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EventKind.Core.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UUID),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName != null ? user.FirstName : ""),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName != null ? user.LastName : ""),
                new Claim(JwtRegisteredClaimNames.Email, user.EmailId),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuPEr SeCrET KeY"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
