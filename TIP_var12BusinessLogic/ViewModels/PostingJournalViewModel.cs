using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class PostingJournalViewModel
    {
        public int? Id { get; set; }
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
    }
}
