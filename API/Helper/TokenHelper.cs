using Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Helper
{
    public static class TokenHelper
    {
        public static SymmetricSecurityKey GenerateKey(IConfiguration configuration)
        {
            var key = configuration.GetSection("JWT").GetValue<string>("SecretKey");
            var keyInBytes = Encoding.ASCII.GetBytes(key);
            var secretKey = new SymmetricSecurityKey(keyInBytes);

            return secretKey;
        }
        public static string GenerateToken(SymmetricSecurityKey key, IList<Claim> claims, string issuer, string audience, DateTime dateTime)
        {
            
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: issuer,
                audience:  audience,
                claims: claims,
                signingCredentials: signinCredentials,
                expires: dateTime

                ) ;

            return new JwtSecurityTokenHandler().WriteToken(jwtToken) ;

        }
    }
}
