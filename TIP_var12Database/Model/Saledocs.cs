using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Saledocs
    {
        public Saledocs()
        {
            Postingjournal = new HashSet<Postingjournal>();
            Saleservices = new HashSet<Saleservices>();
        }

        public int Saledocsid { get; set; }
        public string Employee { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Requestsid { get; set; }

        public virtual Requests Requests { get; set; }
        public virtual ICollection<Postingjournal> Postingjournal { get; set; }
        public virtual ICollection<Saleservices> Saleservices { get; set; }
    }
}
