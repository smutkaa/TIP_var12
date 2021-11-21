using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class SaleDocLogic
    {  
        private readonly ISaleDoc salStorage;
        public SaleDocLogic(ISaleDoc salStorage)
        {
            this.salStorage = salStorage;
        }

        public List<SaleDocViewModel> Read(SaleDocBindingModel model)
        {
            if (model == null)
            {
                return salStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SaleDocViewModel> { salStorage.GetElement(model) };
            }
            return salStorage.GetFilteredList(model);
        }
        public int CreateOrUpdate(SaleDocBindingModel model)
        {
            int code = 0;
            var element = salStorage.GetElement(new SaleDocBindingModel
            {
                Date = model.Date,
                Employee = model.Employee,
                Total = model.Total,
                Requestsid = model.Requestsid
            });;
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой документ");
            }
            if (model.Id.HasValue)
            {
                salStorage.Update(model);
            }
            else
            {
                code = salStorage.Insert(model);
            }
            return code;
        }
        public void Delete(SaleDocBindingModel model)
        {
            var element = salStorage.GetElement(new SaleDocBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Документ не найден");
            }
            salStorage.Delete(model);
        }
    }
}
