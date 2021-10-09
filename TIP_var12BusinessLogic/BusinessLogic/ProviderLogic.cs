using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class ProviderLogic
    {
        private readonly IProvider provStorage;
        public ProviderLogic(IProvider provStorage)
        {
            this.provStorage = provStorage;
        }

        public List<ProviderViewModel> Read(ProvidersBindingModel model)
        {
            return provStorage.GetFullList();
        }
        public void CreateOrUpdate(ProvidersBindingModel model)
        {
            var element = provStorage.GetElement(new ProvidersBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой поставщик");
            }
            if (model.Id.HasValue)
            {
                provStorage.Update(model);
            }
            else
            {
                provStorage.Insert(model);
            }
        }
        public void Delete(ProvidersBindingModel model)
        {
            var element = provStorage.GetElement(new ProvidersBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Поставщик не найден");
            }
            provStorage.Delete(model);
        }
    }
}
