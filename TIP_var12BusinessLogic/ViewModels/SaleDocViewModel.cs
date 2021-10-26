using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class SaleDocViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Сотрудник")]

        public string Employee { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Сумма")]
        public decimal Total { get; set; }

        public int Requestsid { get; set; }

        public Dictionary< int, (string, int)> SaleDocSevices { get; set; }
    }
}
