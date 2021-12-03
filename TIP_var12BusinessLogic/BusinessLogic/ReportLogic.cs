using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.HelperClass;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IPostingJournal postingJournal;
		private readonly IRequest request;
		private readonly IService service;
		private readonly ISaleDoc saleDoc;
		private readonly AccountChartLogic logicAC;
		private List<AccountingChartViewModel> listAC;
		public ReportLogic(IPostingJournal postingJournal, IRequest request, IService service, AccountChartLogic logicAC, ISaleDoc saleDoc)
        {
            this.postingJournal = postingJournal;
			this.request = request;
			this.service = service;
			this.logicAC = logicAC;
			this.saleDoc = saleDoc;
			listAC = logicAC.Read(null);

		}
		public void SaveRequestToPdfFile(ReportsBindingModel model)
		{
			SaveToPdf.CreateDocRequest(new PdfInfo
			{
				FileName = model.FileName,
				Title = "Список выполненных заявок",
				DateFrom = model.DateFrom,
				DateTo = model.DateTo,
				Request = GetRequest(model)
			});
		}
		public void SaveCarsToPdfFile(ReportsBindingModel model)
		{
			SaveToPdf.CreateDocCars(new PdfInfo
			{
				FileName = model.FileName,
				Title = "Список автомобилей",
				DateFrom = model.DateFrom,
				DateTo = model.DateTo,
				Cars = GetCar(model)
			});
		}
		public List<ReportRequestViewModel> GetRequest(ReportsBindingModel model)
		{
			var list = new List<ReportRequestViewModel>();

			var saleDocs = saleDoc.GetFullListReport();

			foreach (var doc in saleDocs)
            {
				list.Add(doc);
				foreach(var service in doc.Services)
                {
					var record = new ReportRequestViewModel
					{
						Request = doc.Request,
						Item = service.Value.Item1,
						Count = service.Value.Item2,
						Retailprice = service.Value.Item3,
						Purchaseprice =0,
						Proceeds = service.Value.Item3
					};
					list.Add(record);
				}
			}
			return list;
			
		}
		public List<ReportCarsViewModel> GetCar(ReportsBindingModel model)
		{
          
			 return postingJournal.GetReportList
				(new PostingJournalBindingModel
				{
					Debitaccount = Convert.ToInt32(listAC.FirstOrDefault(a => a.Number == 41)?.Id),
					Creditaccount = Convert.ToInt32(listAC.FirstOrDefault(a => a.Number == 41)?.Id),
					DateTo = model.DateTo,
					DateFrom = model.DateFrom
				}); ; ;
		}
	}
}
