using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }

        // Navigation Properties
        public ICollection<CartVariation> CartVariations { get; set; }
    }
}
