using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Variation
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public string Memory { get; set; }
        public string RAM { get; set; }
        public string CPU { get; set; }
        public string Style { get; set; }
        public string Model { get; set; }
        public string SpecialFeatures { get; set; }
        public string GraphicsDescription { get; set; }
        public string SKU { get; set; }
        public int StockQuantity { get; set; }

        //public List<string> Images { get; set; }

        // Navigation property
        //[ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        //public Branch Branch { get; set; }
        //public Guid BranchId { get; set; }

        public ICollection<CartVariation> CartVariations { get; set; }


    }
}
