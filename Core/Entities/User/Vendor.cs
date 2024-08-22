using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.User
{
    public class Vendor : User
    {

        // navigation props
        public List<Store> Stores { get; set; }


    }
}
