using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        //public List<string> Images { get; set; }


        // *** Navigation Property *** 

        // many variations
        public List<Variation> Variations { get; set; }

        #region one branch for each product

        public Branch Branch { get; set; }
        //[ForeignKey("Branch")]
        public Guid BranchId { get; set; }

        #endregion

        #region one Category for each product

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        #endregion
    }
}
