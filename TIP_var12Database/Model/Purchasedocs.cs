using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Purchasedocs
    {
        public Purchasedocs()
        {
            Postingjournal = new HashSet<Postingjournal>();
        }

        public int Purchasedocid { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Providerid { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Providers Provider { get; set; }
        public virtual ICollection<Postingjournal> Postingjournal { get; set; }
    }
}
