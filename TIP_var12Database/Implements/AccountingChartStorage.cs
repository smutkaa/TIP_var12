using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12Database.Implements
{
	public class AccountingChartStorage: IAccountingChart
	{
        public List<AccountingChartViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Accountcharts.Select(rec => new AccountingChartViewModel
                {
                    Id = rec.Accountchartid,
                    Name=rec.Name,
                    Number = rec.Number,
                    Subconto1 = rec.Subconto1,
                    Subconto2 = rec.Subconto2
                })
                .ToList();
            }
        }

        public List<AccountingChartViewModel> GetFilteredList(AccountingChartBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new mydbContext())
            {
                return context.Accountcharts.Select(rec => new AccountingChartViewModel
                {
                    Id = rec.Accountchartid,
                    Name = rec.Name,
                    Number = rec.Number,
                    Subconto1 = rec.Subconto1,
                    Subconto2 = rec.Subconto2
                })
                 .ToList();
            }
        }
    }
}
