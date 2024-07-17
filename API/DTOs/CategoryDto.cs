using Core.Entities;

namespace API.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public ICollection<string>? ChildCategories { get; set; }
        public ICollection<string>? Products { get; set; }

    }
}
