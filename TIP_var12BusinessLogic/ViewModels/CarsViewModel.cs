using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class CarsViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Закупочная цена")]
        public decimal Purchaseprice { get; set; }
        [DisplayName("Розничная цена")]
        public decimal Retailprice { get; set; }
        public int Seriesid { get; set; }
        [DisplayName("Серия")]
        public string SeriesName { get; set; }
    }
}
