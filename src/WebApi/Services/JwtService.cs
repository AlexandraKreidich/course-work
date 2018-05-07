using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.IdentityModel.Tokens;
using WebApi.Contracts;

namespace WebApi.Services
{
    [UsedImplicitly]
    public class JwtService : IJwtService
    {
        [NotNull]
        private readonly IWebApiSettings _settings;

        public JwtService([NotNull] IWebApiSettings settings)
        {
            _settings = settings;
        }

        public string GenerateJwtToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(_settings.JwtExpireDays));

            JwtSecurityToken token = new JwtSecurityToken(
                _settings.JwtIssuer,
                _settings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
