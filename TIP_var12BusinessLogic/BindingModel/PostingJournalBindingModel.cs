﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.BindingModel
{
    public class PostingJournalBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Debitaccount { get; set; }
        public string Subcontodebit1 { get; set; }
        public string Subcontodebit2 { get; set; }
        public int Creditaccount { get; set; }
        public string Subcontocredit1 { get; set; }
        public string Subcontocredit2 { get; set; }
        public int? Count { get; set; }
        public string Comment { get; set; }
        public decimal Total { get; set; }
        public int? Saledocsid { get; set; }
        public int? Purchasedocid { get; set; }

    }
}
