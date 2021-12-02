using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class ReportCarsViewModel
    {
        public int IdCars { get; set; }
        public string CarName { get; set; }
        public string Series { get; set; }
        public int Count { get; set; }

        public decimal  StartBalance { get; set; }
        public decimal Receipt { get; set; }
        public decimal Сonsumption { get; set; }
        public decimal EndBalance { get; set; }
    }
}
