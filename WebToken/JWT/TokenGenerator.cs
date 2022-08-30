using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IWebToken.DTO;
using IWebToken.JWT;
using Microsoft.IdentityModel.Tokens;
using WebToken.Setting;

namespace WebToken.JWT
{
    internal class TokenGenerator : ITokenGenerator
    {
        #region Vars
        public AuthSettings AppSetting { get; }
        #endregion

        #region CTRS
        public TokenGenerator(AuthSettings appSettings)
        {
            AppSetting = appSettings;
        }
        #endregion

        public string CreateToken(List<UserClaim> userClaims, string audience, string issuer)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(AppSetting.Secret);

            List<Claim> claims = new List<Claim>();
            if (userClaims?.Count > default(int))
            {
                claims = userClaims.Select(x => new Claim(x.Name.ToString(), x.Value)).ToList();
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(AppSetting.TokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                Audience = audience,
                Issuer = issuer
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

      
    }
}
