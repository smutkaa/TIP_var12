using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Saleservices
    {
        public int Saleservicesid { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public int Servicesid { get; set; }
        public int Saledocsid { get; set; }

        public virtual Saledocs Saledocs { get; set; }
        public virtual Services Services { get; set; }
    }
}
