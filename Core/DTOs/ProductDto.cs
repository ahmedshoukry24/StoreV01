namespace Core.DTOs
{
    public class ProductDto
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid BranchId { get; set; }
        public Guid CategoryId { get; set; }

    }
}
