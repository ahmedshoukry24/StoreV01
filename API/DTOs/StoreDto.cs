using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class StoreDto
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
