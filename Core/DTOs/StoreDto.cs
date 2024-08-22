using Core.DTOs.Models;
using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class StoreDto
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public string VendorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
        //public string? Address { get; set; }
        
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }

        public List<BranchProps> Branches { get; set; }
    }
}
