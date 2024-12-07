using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.User
{
    public class User : IdentityUser<Guid>
    {
        //public string Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VisiblePassword { get; set; }

        //// navigation props
        //public Employee Employee { get; set; }
        //public Vendor Vendor { get; set; }
        //public Customer Customer { get; set; }
    }
}
