using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Media
    {
        public Guid Id { get; set; }
        public string URL { get; set; }


        //Navigation Props
        public Store Store { get; set; }
        public Guid? StoreId { get; set; }

        public Branch Branch { get; set; }
        public Guid? BranchId { get; set; }


    }
}
