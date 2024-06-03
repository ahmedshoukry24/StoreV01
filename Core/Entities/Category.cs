using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation Properties

        public Category ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public ICollection<Category> ChildCategories { get; set;}
        public ICollection<Product> Products  { get; set;}

    }
}
