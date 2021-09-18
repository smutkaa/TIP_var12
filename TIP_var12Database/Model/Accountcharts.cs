using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Accountcharts
    {
        public Accountcharts()
        {
            PostingjournalCreditaccountNavigation = new HashSet<Postingjournal>();
            PostingjournalDebitaccountNavigation = new HashSet<Postingjournal>();
            Subdivision = new HashSet<Subdivision>();
        }

        public int Accountchartid { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Subconto1 { get; set; }
        public string Subconto2 { get; set; }

        public virtual ICollection<Postingjournal> PostingjournalCreditaccountNavigation { get; set; }
        public virtual ICollection<Postingjournal> PostingjournalDebitaccountNavigation { get; set; }
        public virtual ICollection<Subdivision> Subdivision { get; set; }
    }
}
