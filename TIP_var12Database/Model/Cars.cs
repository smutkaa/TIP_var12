using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Cars
    {
        public Cars()
        {
            Purchasedocs = new HashSet<Purchasedocs>();
            Requests = new HashSet<Requests>();
        }

        public int Carid { get; set; }
        public string Name { get; set; }
        public decimal Purchaseprice { get; set; }
        public decimal Retailprice { get; set; }
        public int Seriesid { get; set; }

        public virtual Series Series { get; set; }
        public virtual ICollection<Purchasedocs> Purchasedocs { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
