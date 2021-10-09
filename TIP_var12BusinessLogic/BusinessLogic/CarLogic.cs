using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class CarLogic
    {
        private readonly ICars carStorage;
        public CarLogic(ICars carStorage)
        {
            this.carStorage = carStorage;
        }
        
        public List<CarsViewModel> Read(CarBindingModel model)
        {
            return carStorage.GetFullList();
        }
        public void CreateOrUpdate(CarBindingModel model)
        {
            var element = carStorage.GetElement(new CarBindingModel
            {
                Name = model.Name,
                Purchaseprice = model.Purchaseprice,
                Retailprice = model.Retailprice,
                Seriesid = model.Seriesid
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая машина");
            }
            if (model.Id.HasValue)
            {
                carStorage.Update(model);
            }
            else
            {
                carStorage.Insert(model);
            }
        }
        public void Delete(CarBindingModel model)
        {
            var element = carStorage.GetElement(new CarBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            carStorage.Delete(model);
        }
    }
}
