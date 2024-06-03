using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Branch 
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }


        #region *** Navigation Property *** 

        // many products in one branch
        public List<Product> Products { get; set; }

        #region each branch under one store
        public Store Store { get; set; }
        public Guid StoreId { get; set; } 
        #endregion

        #endregion
    }
}
