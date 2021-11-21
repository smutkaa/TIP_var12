using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface IPurchaseDoc
    {
        List<PurchasedocsViewModel> GetFullList();
        PurchasedocsViewModel GetElement(PurchasedocsBindingModel model);
        List<PurchasedocsViewModel> GetFilteredList(PurchasedocsBindingModel model);
        int Insert(PurchasedocsBindingModel model);
        void Update(PurchasedocsBindingModel model);
        void Delete(PurchasedocsBindingModel model);
    }
}
