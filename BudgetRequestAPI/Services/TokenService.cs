using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace BudgetRequestAPI.Services
{
    public class TokenService : ITokenService
    {
        public readonly SymmetricSecurityKey _symmetricSecurityKey;
        private BinaryReader ismanager;

        public TokenService(IConfiguration configuration)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(UserInfo userInfo)
        {
            var claim = new List<Claim>()
            {
               new Claim(JwtRegisteredClaimNames.Sub,userInfo.UserName),
               new Claim("userid", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
               new Claim(ClaimTypes.Role,userInfo.IsManager.ToString()),
               new Claim("managerId",userInfo.ManagerId.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credential = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credential,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
