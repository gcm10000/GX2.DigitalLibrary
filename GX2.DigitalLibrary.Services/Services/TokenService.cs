using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GX2.DigitalLibrary.Services.Services
{
    
    public class TokenService : BaseServices, ITokenService
    {
        public TokenService(IConfiguration configuration) : base(configuration)
        {}

        public string GenerateToken(DateTime expires, string username, string role)
        {
            return GenerateToken(base._configuration["Jwt:Key"], expires, username, role);
        }

        public string GenerateToken(string secret, DateTime expires, string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
