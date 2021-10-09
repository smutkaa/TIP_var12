using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface ICustomer
    {
        List<CustomerViewModel> GetFullList();
        CustomerViewModel GetElement(CustomerBindingModel model);
        void Insert(CustomerBindingModel model);
        void Update(CustomerBindingModel model);
        void Delete(CustomerBindingModel model);
    }
}
