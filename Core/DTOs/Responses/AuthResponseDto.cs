using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Responses
{
    public class AuthResponseDto
    {

        public string Token { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public string userId { get; set; }


        public static AuthResponseDto ErrorResponse(string error)
        {
            return new AuthResponseDto
            {
                ErrorMessage = error,
                Success = false,
                Token = null,
                ExpiryDate = null,
                userId = null
            };
        }
    }
}
