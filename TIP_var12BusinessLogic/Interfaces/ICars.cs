using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface  ICars
    {
        List<CarsViewModel> GetFullList();
        CarsViewModel GetElement(CarBindingModel model);
        void Insert(CarBindingModel model);
        void Update(CarBindingModel model);
        void Delete(CarBindingModel model);
    }
}
