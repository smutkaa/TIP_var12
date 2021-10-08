using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface  ISeries
    {
        List<SeriesViewModel> GetFullList();
        SeriesViewModel GetElement(SeriesBindingModel model);
        void Insert(SeriesBindingModel model);
        void Update(SeriesBindingModel model);
        void Delete(SeriesBindingModel model);
    }
}
