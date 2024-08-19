using Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

        public static async Task<object> CreateTokenObject<T> (T user, IConfiguration configuration,UserManager<T> userManager) where T : class
        {
            string? issuer = configuration.GetSection("issuer").GetValue<string>("issuer");
            string? audienc = configuration.GetSection("issuer").GetValue<string>("audience");
            //IList<Claim> claims = await userManager.GetClaimsAsync(user);
            IList<Claim> claims = await userManager.GetClaimsAsync(user);
            DateTime expiryDate = DateTime.Now.AddDays(3);

            SymmetricSecurityKey key = TokenHelper.GenerateKey(configuration);
            string token = TokenHelper.GenerateToken(key, claims, issuer, audienc, expiryDate);

            return new
            {
                Token = token,
                ExpiryDate = expiryDate
            };
        }
    }
}
