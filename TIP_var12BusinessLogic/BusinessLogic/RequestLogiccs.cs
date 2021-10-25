using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class RequestLogiccs
    {
        private readonly IRequest reqStorage;
        public RequestLogiccs(IRequest reqStorage)
        {
            this.reqStorage = reqStorage;
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            if (model == null)
            {
                return reqStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RequestViewModel> { reqStorage.GetElement(model) };
            }

            return reqStorage.GetFullList();
        }
        public void CreateOrUpdate(RequestBindingModel model)
        {
            var element = reqStorage.GetElement(new RequestBindingModel
            {
                Date = model.Date,
                Quantity = model.Quantity,
                Carid = model.Carid,
                Customerid = model.Customerid
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая заявка");
            }
            if (model.Id.HasValue)
            {
                reqStorage.Update(model);
            }
            else
            {
                reqStorage.Insert(model);
            }
        }
        public void Delete(RequestBindingModel model)
        {
            var element = reqStorage.GetElement(new RequestBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Заявка не найдена");
            }
            reqStorage.Delete(model);
        }
    }
}
