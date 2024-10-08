using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Responses
{
    public class BranchResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Guid? BranchId { get; set; }


        public static BranchResponse SuccessResponse(string message, Guid branchId)
        {
            return new BranchResponse { Status = true, Message = message, BranchId = branchId };
        }

        public static BranchResponse ErrorResponse(string message)
        {
            return new BranchResponse { Status = false, Message = message, BranchId = null };
        }
    }
}
