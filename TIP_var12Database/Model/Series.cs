using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Series
    {
        public Series()
        {
            Cars = new HashSet<Cars>();
        }

        public int Seriesid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
