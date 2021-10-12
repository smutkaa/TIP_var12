using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class SeriesLogic
    {
        private readonly ISeries serStorage;
        public SeriesLogic(ISeries serStorage)
        {
            this.serStorage = serStorage;
        }
        public List<SeriesViewModel> Read(SeriesBindingModel model)
        {
            if (model == null)
            {
                return serStorage.GetFullList();
            }
                if (model.Id.HasValue)
			{
                return new List<SeriesViewModel> { serStorage.GetElement(model)};
            }
            return serStorage.GetFullList();
        }
        public void CreateOrUpdate(SeriesBindingModel model)
        {
            var element = serStorage.GetElement(new SeriesBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id )
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
        public void Delete(SeriesBindingModel model)
        {
            var element = serStorage.GetElement(new SeriesBindingModel
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
