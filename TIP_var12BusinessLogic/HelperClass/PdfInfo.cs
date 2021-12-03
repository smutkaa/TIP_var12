using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.HelperClass
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportRequestViewModel> Request { get; set; }
        public List<ReportCarsViewModel> Cars { get; set; }
    }
}
