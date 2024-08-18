using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Store
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        //public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public bool IsDelete { get; set; }
        public DateTime? DeletedDate { get; set; }



        // Navigation Properties
        public List<Branch> Branches { get; set; }

    }
}
