using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Customerid { get; set; }
        [DisplayName("Автомобиль")]
        public string CarName { get; set; }
        [DisplayName("Покупатель")]
        public string CustomerName { get; set; }
        
    }
}
