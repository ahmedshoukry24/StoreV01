namespace Core.DTOs
{
    public class BranchDto
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DeletedDate { get; set; }

        public Guid StoreId { get; set; }
    }
}
