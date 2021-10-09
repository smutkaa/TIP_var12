using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface IProvider
    {
        List<ProviderViewModel> GetFullList();
        ProviderViewModel GetElement(ProvidersBindingModel model);
        void Insert(ProvidersBindingModel model);
        void Update(ProvidersBindingModel model);
        void Delete(ProvidersBindingModel model);
    }
}
