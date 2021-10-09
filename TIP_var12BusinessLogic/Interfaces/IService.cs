using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface IService
    {
        List<ServiceViewModel> GetFullList();
        ServiceViewModel GetElement(ServiceBindingModel model);
        void Insert(ServiceBindingModel model);
        void Update(ServiceBindingModel model);
        void Delete(ServiceBindingModel model);
    }
}
