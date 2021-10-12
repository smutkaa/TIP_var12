using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class SubdivisionViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Подразделение")]
        public string Name { get; set; }
        public int Accountchartid { get; set; }
        [DisplayName("Счет")]
        public string AccountchartName { get; set; }
    }
}
