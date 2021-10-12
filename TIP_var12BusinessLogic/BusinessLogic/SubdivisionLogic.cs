using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class SubdivisionLogic
    {
        private readonly ISubdivision subStorage;
        public SubdivisionLogic(ISubdivision subStorage)
        {
            this.subStorage = subStorage;
        }
        public List<SubdivisionViewModel> Read(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return subStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SubdivisionViewModel> { subStorage.GetElement(model) };
            }
            return subStorage.GetFullList();
        }
        public void CreateOrUpdate(SubdivisionBindingModel model)
        {
            var element = subStorage.GetElement(new SubdivisionBindingModel
            {
                Name = model.Name,

            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая серия");
            }
            if (model.Id.HasValue)
            {
                subStorage.Update(model);
            }
            else
            {
                subStorage.Insert(model);
            }
        }
        public void Delete(SubdivisionBindingModel model)
        {
            var element = subStorage.GetElement(new SubdivisionBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Задача не найдена");
            }
            subStorage.Delete(model);
        }
    }
}
