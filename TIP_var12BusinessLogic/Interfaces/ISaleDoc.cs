using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface ISaleDoc
    {
        List<SaleDocViewModel> GetFullList();
        List<SaleDocViewModel> GetFilteredList(SaleDocBindingModel model);
        SaleDocViewModel GetElement(SaleDocBindingModel model);
        int Insert(SaleDocBindingModel model);
        void Update(SaleDocBindingModel model);
        void Delete(SaleDocBindingModel model);
    }
}
