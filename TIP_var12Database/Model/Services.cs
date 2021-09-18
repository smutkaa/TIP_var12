using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Services
    {
        public Services()
        {
            Saleservices = new HashSet<Saleservices>();
        }

        public int Servicesid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Subdivisionid { get; set; }

        public virtual Subdivision Subdivision { get; set; }
        public virtual ICollection<Saleservices> Saleservices { get; set; }
    }
}
