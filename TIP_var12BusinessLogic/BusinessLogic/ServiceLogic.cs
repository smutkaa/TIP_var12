using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class ServiceLogic
    {
        private readonly IService serStorage;
        public ServiceLogic(IService serStorage)
        {
            this.serStorage = serStorage;
        }
        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            if (model == null)
            {
                return serStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ServiceViewModel> { serStorage.GetElement(model) };
            }
            
            return serStorage.GetFullList();
        }
        public void CreateOrUpdate(ServiceBindingModel model)
        {
            var element = serStorage.GetElement(new ServiceBindingModel
            {
                Name = model.Name,
                Price = model.Price,
                Subdivisionid = model.Subdivisionid
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая серия");
            }
            if (model.Id.HasValue)
            {
                serStorage.Update(model);
            }
            else
            {
                serStorage.Insert(model);
            }
        }
        public void Delete(ServiceBindingModel model)
        {
            var element = serStorage.GetElement(new ServiceBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            serStorage.Delete(model);
        }
    }
}
