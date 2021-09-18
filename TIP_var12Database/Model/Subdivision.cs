using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Subdivision
    {
        public Subdivision()
        {
            Services = new HashSet<Services>();
        }

        public int Subdivisionid { get; set; }
        public string Name { get; set; }
        public int Accountchartid { get; set; }

        public virtual Accountcharts Accountchart { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
