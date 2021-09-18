using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
	public class AccountingChartViewModel
	{
        public int? Id { get; set; }
        [DisplayName("Номер")]
		public int Number { get; set; }
		[DisplayName("Название")]
		public string Name { get; set; }
		[DisplayName("Субконто1")]
		public string Subconto1 { get; set; }
		[DisplayName("Субконто2")]
		public string Subconto2 { get; set; }
	}
}
