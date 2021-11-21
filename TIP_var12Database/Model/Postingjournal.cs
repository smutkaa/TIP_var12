using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class Postingjournal
    {
        public int Postingjournalid { get; set; }
        public DateTime Date { get; set; }
        public int Debitaccount { get; set; }
        public string Subcontodebit1 { get; set; }
        public string Subcontodebit2 { get; set; }
        public int Creditaccount { get; set; }
        public string Subcontocredit1 { get; set; }
        public string Subcontocredit2 { get; set; }
        public decimal Total { get; set; }
        public int? Saledocsid { get; set; }
        public int? Purchasedocid { get; set; }
        public string Comment { get; set; }
        public int? Count { get; set; }

        public virtual Accountcharts CreditaccountNavigation { get; set; }
        public virtual Accountcharts DebitaccountNavigation { get; set; }
        public virtual Purchasedocs Purchasedoc { get; set; }
        public virtual Saledocs Saledocs { get; set; }
    }
}
