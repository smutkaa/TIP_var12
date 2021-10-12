using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TIP_var12BusinessLogic.ViewModels
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }
        [DisplayName("ФИО")]
        public string Fio { get; set; }
    }
}
