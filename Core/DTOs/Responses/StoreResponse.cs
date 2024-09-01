using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Responses
{
    public class StoreResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Guid? StoreId { get; set; }

        public static StoreResponse ErrorResponse(string errorMessage)
        {
            return new StoreResponse
            {
                Status = false,
                Message = errorMessage,
                StoreId = null
            };
        }

        public static StoreResponse SuccessResponse(string message, Guid storeId)
        {
            return new StoreResponse { Status = true, Message = message, StoreId = storeId };
        }
    }
}
