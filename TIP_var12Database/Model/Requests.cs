using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Requests
    {
        public Requests()
        {
            Saledocs = new HashSet<Saledocs>();
        }

        public int Requestsid { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Customerid { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Saledocs> Saledocs { get; set; }
    }
}
