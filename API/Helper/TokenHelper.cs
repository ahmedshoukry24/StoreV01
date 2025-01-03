﻿using Core.DTOs.Responses;
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

        public static async Task<AuthResponseDto> CreateTokenObject<T> (T user, IConfiguration configuration,UserManager<T> userManager, string userId) where T : class
        {
            string? issuer = configuration.GetSection("JWT").GetValue<string>("issuer");
            string? audienc = configuration.GetSection("JWT").GetValue<string>("audience");
            //IList<Claim> claims = await userManager.GetClaimsAsync(user);
            IList<Claim> claims = await userManager.GetClaimsAsync(user);
            DateTime expiryDate = DateTime.Now.AddDays(3);

            //if(type == 1)
            //    claims.Add(new Claim("Current", "Hi_This_Is_Current_Claim_Tor_Testing"));

            SymmetricSecurityKey key = TokenHelper.GenerateKey(configuration);
            string token = TokenHelper.GenerateToken(key, claims, issuer, audienc, expiryDate);

            return new
            AuthResponseDto {
                Token = token,
                ExpiryDate = expiryDate,
                ErrorMessage = string.Empty,
                Success = true,
                userId = userId
            };
        }
    }
}
