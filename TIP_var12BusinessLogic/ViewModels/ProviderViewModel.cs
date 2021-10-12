using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
   public  class ProviderViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
