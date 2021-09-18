using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
	public class AccountChartLogic
	{
        private readonly IAccountingChart _acStorage;

        public AccountChartLogic(IAccountingChart acStorage)
        {
            _acStorage = acStorage;
        }

        public List<AccountingChartViewModel> Read(AccountingChartBindingModel model)
        {
            if (model == null)
            {
                return _acStorage.GetFullList();
            }
            
            return _acStorage.GetFilteredList(model);
        }


    }
}
