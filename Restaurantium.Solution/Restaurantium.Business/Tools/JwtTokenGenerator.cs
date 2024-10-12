using Microsoft.IdentityModel.Tokens;
using Restaurantium.Dto.AppUserDtos;
using Restaurantium.Dto.TokenDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Tools
{
    public class JwtTokenGenerator
    {
        public static ResultTokenResponseDto GenerateToken(ResultCheckAppUserDto result)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(result.Role))
                claims.Add(new Claim(ClaimTypes.Role, result.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier,result.ID.ToString()));

            if(!string.IsNullOrWhiteSpace(result.Username))
                claims.Add(new Claim("Username",result.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signInCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new(issuer: JwtTokenDefaults.ValidIssuer,audience: JwtTokenDefaults.ValidAudience,claims: claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signInCredentials);
            
            JwtSecurityTokenHandler handler = new();

            return new ResultTokenResponseDto(handler.WriteToken(token),expireDate);
        }
    }
}
