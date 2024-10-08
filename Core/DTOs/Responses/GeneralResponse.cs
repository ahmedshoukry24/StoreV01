using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Responses
{
    public class GeneralResponse<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }

        public static GeneralResponse<T> ErrorResponse(string errorMessage)
        {
            return new GeneralResponse<T> { Status = false,Data= null,Message= errorMessage};
        }

        public static GeneralResponse<T> SuccessResponse(IEnumerable<T> obj)
        {
            return new GeneralResponse<T> { Status = true, Data = obj, Message = "" };
        }


    }
}
