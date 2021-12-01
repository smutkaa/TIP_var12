using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class ReportRequestViewModel
    {
        public string Request { get; set; }
        public string Item { get; set; }
        public int Count { get; set; }
        public decimal Purchaseprice { get; set; }
        public decimal Retailprice { get; set; }
        public decimal Proceeds { get; set; }
    }
}
