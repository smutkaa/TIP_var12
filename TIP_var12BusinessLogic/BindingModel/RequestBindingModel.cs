﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TIP_var12BusinessLogic.BindingModel
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Carid { get; set; }
        public int Customerid { get; set; }
    }
}
