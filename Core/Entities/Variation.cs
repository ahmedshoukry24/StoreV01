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
        public string SKU { get; set; }
        public int StockQuantity { get; set; }

        //public List<string> Images { get; set; }

        // Navigation property
        //[ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<CartVariation> CartVariations { get; set; }


    }
}
