using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Customers
    {
        public Customers()
        {
            Requests = new HashSet<Requests>();
        }

        public int Customerid { get; set; }
        public string Fio { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
    }
}
