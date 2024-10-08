using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BranchProducts
    {

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Navigation props
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Branch Branch { get; set; }
        public Guid BranchId { get; set; }
    }
}
