using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
   public  class SeriesViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Серия")]
        public string Name { get; set; }
    }
}
