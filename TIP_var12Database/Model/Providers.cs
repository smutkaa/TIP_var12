using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Providers
    {
        public Providers()
        {
            Purchasedocs = new HashSet<Purchasedocs>();
        }

        public int Providerid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Purchasedocs> Purchasedocs { get; set; }
    }
}
