using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface IRequest
    {
        List<RequestViewModel> GetFullList();
        RequestViewModel GetElement(RequestBindingModel model);
        void Insert(RequestBindingModel model);
        void Update(RequestBindingModel model);
        void Delete(RequestBindingModel model);
    }
}
