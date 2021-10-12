using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Стоимость")]
        public decimal Price { get; set; }
        public int Subdivisionid { get; set; }
        [DisplayName("Подразделение")]
        public string SubvisionName { get; set; }
    }
}
