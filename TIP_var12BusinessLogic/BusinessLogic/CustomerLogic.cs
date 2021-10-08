using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.Interfaces;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly ICustomer custStorage;
        public CustomerLogic(ICustomer custStorage)
        {
            this.custStorage = custStorage;
        }
        /*
        public List<CarsViewModel> Read(CarBindingModel model)
        {
            if (model == null)
            {
                return carStorage.GetFullList();
            }

            return carStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(TaskBindingModel model)
        {
            var element = _taskStorage.GetElement(new TaskBindingModel
            {
                Name = model.Name,
                Text = model.Text,
                Projectid = model.Projectid
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая задача");
            }
            if (model.Id.HasValue)
            {
                _taskStorage.Update(model);
            }
            else
            {
                _taskStorage.Insert(model);
            }
        }
        public void Delete(TaskBindingModel model)
        {
            var element = _taskStorage.GetElement(new TaskBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            _taskStorage.Delete(model);
        }*/
    }
}
