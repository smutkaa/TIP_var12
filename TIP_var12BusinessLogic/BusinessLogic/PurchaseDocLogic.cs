using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class PurchaseDocLogic
    {
        private readonly IPurchaseDoc purStorage;
        public PurchaseDocLogic(IPurchaseDoc purStorage)
        {
            this.purStorage = purStorage;
        }

        public List<PurchasedocsViewModel> Read(PurchasedocsBindingModel model)
        {
            if (model == null)
            {
                return purStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchasedocsViewModel> { purStorage.GetElement(model) };
            }

            return purStorage.GetFilteredList(model);
        }
        public int CreateOrUpdate(PurchasedocsBindingModel model)
        {
            int code = 0;
            var element = purStorage.GetElement(new PurchasedocsBindingModel
            {
                Date = model.Date,
                Quantity = model.Quantity,
                Carid = model.Carid,
                Providerid = model.Providerid
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой документ");
            }
            if (model.Id.HasValue)
            {
                purStorage.Update(model);
            }
            else
            {
                code = purStorage.Insert(model);
            }
            return code; 
        }
        public void Delete(PurchasedocsBindingModel model)
        {
            var element = purStorage.GetElement(new PurchasedocsBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Документ не найден");
            }
            purStorage.Delete(model);
        }
    }
}
