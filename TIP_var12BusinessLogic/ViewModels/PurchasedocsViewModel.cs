using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class PurchasedocsViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Providerid { get; set; }
        [DisplayName("Автомобиль")]
        public string CarName { get; set; }
        [DisplayName("Поставщик")]
        public string ProviderName { get; set; }
    }
}
