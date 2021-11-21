using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class PostingJournalViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("ДТ")]
        public int Debitaccount { get; set; }
        [DisplayName("Субконто дебита")]
        public string Subcontodebit1 { get; set; }
        [DisplayName("Субконто дебита")]
        public string Subcontodebit2 { get; set; }
        [DisplayName("КТ")]
        public int Creditaccount { get; set; }
        [DisplayName("Субконто кредита")]
        public string Subcontocredit1 { get; set; }
        [DisplayName("Субконто кредита")]
        public string Subcontocredit2 { get; set; }
        [DisplayName("Количество")]
        public int? Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Total { get; set; }
        [DisplayName("Документ-продажа")]
        public int? Saledocsid { get; set; }
        [DisplayName("Документ-закупка")]
        public int? Purchasedocid { get; set; }
    }
}
