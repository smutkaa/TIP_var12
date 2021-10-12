using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface ISubdivision
    {
        List<SubdivisionViewModel> GetFullList();
        SubdivisionViewModel GetElement(SubdivisionBindingModel model);
        void Insert(SubdivisionBindingModel model);
        void Update(SubdivisionBindingModel model);
        void Delete(SubdivisionBindingModel model);
    }
}
