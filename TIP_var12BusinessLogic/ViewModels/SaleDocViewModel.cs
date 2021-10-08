using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class SaleDocViewModel
    {
        public int? Id { get; set; }
        public string Employee { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Requestsid { get; set; }

        public Dictionary<int, (int, decimal)> SaleDocSevices { get; set; }
    }
}
