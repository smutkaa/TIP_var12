using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Customerid { get; set; }
    }
}
