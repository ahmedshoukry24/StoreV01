using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CartVariation
    {
        public int Quantity { get; set; }

        // Navigation Properties
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }

        public Variation Variation { get; set; }
        public Guid VariationId { get; set; }
    }
}
