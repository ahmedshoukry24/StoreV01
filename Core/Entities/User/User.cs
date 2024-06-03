using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.User
{
    public class User : IdentityUser
    {
        public string Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
