using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly ICustomer custStorage;
        public CustomerLogic(ICustomer custStorage)
        {
            this.custStorage = custStorage;
        }
        
        public List<CustomerViewModel> Read(CustomerBindingModel model)
        {
            return custStorage.GetFullList();
        }
        public void CreateOrUpdate(CustomerBindingModel model)
        {
            var element = custStorage.GetElement(new CustomerBindingModel
            {
                Fio = model.Fio
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой покупатель");
            }
            if (model.Id.HasValue)
            {
                custStorage.Update(model);
            }
            else
            {
                custStorage.Insert(model);
            }
        }
        public void Delete(CustomerBindingModel model)
        {
            var element = custStorage.GetElement(new CustomerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупатель не найден");
            }
            custStorage.Delete(model);
        }
    }
}
