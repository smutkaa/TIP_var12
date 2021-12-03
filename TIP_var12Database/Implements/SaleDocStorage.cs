using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;


namespace TIP_var12Database.Implements
{
	public class SaleDocStorage: ISaleDoc
	{
        public List<SaleDocViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Saledocs
               .Include(rec => rec.Saleservices)
               .ThenInclude(rec => rec.Services)
               .ToList()
               .Select(rec => new SaleDocViewModel
               {
                   Id = rec.Saledocsid,
                   Date = rec.Date,
                   Employee = rec.Employee,
                   Requestsid = rec.Requestsid,
                   Total = rec.Total,
                   SaleDocSevices = rec.Saleservices.ToDictionary(recPC => recPC.Servicesid, recPC => (recPC.Services?.Name, recPC.Number))
               })
               .ToList();
            }
        }
        public List<ReportRequestViewModel> GetFullListReport()
        {
            using (var context = new mydbContext())
            {
                return context.Saledocs
               .Include(rec => rec.Requests)
               .ThenInclude(rec => rec.Car)
               .Include(rec => rec.Saleservices)
               .ThenInclude(rec => rec.Services)
               .ToList()
               .Select(rec => new ReportRequestViewModel
               {
                   Request = Convert.ToString(rec.Requestsid),
                   Item = rec.Requests.Car.Name,
                   Count = rec.Requests.Quantity,
                   Retailprice = rec.Requests.Quantity * rec.Requests.Car.Retailprice,
                   Purchaseprice = rec.Requests.Quantity * rec.Requests.Car.Purchaseprice,
                   Proceeds = (rec.Requests.Quantity * rec.Requests.Car.Retailprice) - rec.Requests.Quantity * rec.Requests.Car.Purchaseprice,
                   Services = rec.Saleservices.ToDictionary(recPC => recPC.Saleservicesid, recPC => (recPC.Services?.Name, recPC.Number, recPC.Services.Price)),
               })
               .ToList();
            }
        }
        public List<SaleDocViewModel> GetFilteredList(SaleDocBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                return context.Saledocs
                   .Include(rec => rec.Saleservices)
                   .ThenInclude(rec => rec.Services)
                   .Where(rec => rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                   .ToList()
                   .Select(rec => new SaleDocViewModel
                   {
                       Id = rec.Saledocsid,
                       Date = rec.Date,
                       Employee = rec.Employee,
                       Requestsid = rec.Requestsid,
                       Total = rec.Total,
                       SaleDocSevices = rec.Saleservices.ToDictionary(recPC => recPC.Servicesid, recPC => (recPC.Services.Name, recPC.Number))
                   })
               .ToList();
            }
        }
        public SaleDocViewModel GetElement(SaleDocBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var doc = context.Saledocs
                .Include(rec => rec.Saleservices)
               .ThenInclude(rec => rec.Services)
               .FirstOrDefault(rec =>  rec.Saledocsid == model.Id);
                return doc != null ?
                new SaleDocViewModel
                {
                    Id = doc.Saledocsid,
                    Date = doc.Date,
                    Employee = doc.Employee,
                    Requestsid = doc.Requestsid,
                    Total = doc.Total,
                    SaleDocSevices = doc.Saleservices.ToDictionary(recPC => recPC.Servicesid, recPC => (recPC.Services?.Name, recPC.Number))
                } : null;
            }
        }
        public int Insert(SaleDocBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Saledocs aircraft = CreateModel(model, new Saledocs());
                        context.Saledocs.Add(aircraft);
                        context.SaveChanges();
                        aircraft = CreateModel(model, aircraft, context);
                       
                        transaction.Commit();
                        Saledocs element = context.Saledocs.FirstOrDefault(rec => rec.Saledocsid == aircraft.Saledocsid);
                        return element.Saledocsid;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(SaleDocBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Saledocs.FirstOrDefault(rec => rec.Saledocsid ==  model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(SaleDocBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Saledocs element = context.Saledocs.FirstOrDefault(rec => rec.Saledocsid ==  model.Id);
                if (element != null)
                {
                    context.Saledocs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Saledocs CreateModel(SaleDocBindingModel model, Saledocs saledocs)
        {
            saledocs.Date = model.Date;
            saledocs.Employee = model.Employee;
            saledocs.Requestsid = model.Requestsid;
            saledocs.Total = model.Total;
            return saledocs;
        }

        private Saledocs CreateModel(SaleDocBindingModel model, Saledocs saledocs, mydbContext context)
        {
            saledocs.Date = model.Date;
            saledocs.Employee = model.Employee;
            saledocs.Requestsid = model.Requestsid;
            saledocs.Total = model.Total;
            if (model.Id.HasValue)
            {
                var saleDocService = context.Saleservices.Where(rec => rec.Saledocsid == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.Saleservices.RemoveRange(saleDocService.Where(rec => !model.SaleDocSevices.ContainsKey(rec.Servicesid)).ToList());
                var newTablePart = saleDocService.Where(rec => model.SaleDocSevices.ContainsKey(rec.Servicesid)).ToList();

                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in newTablePart)
                {
                    updateComponent.Number = model.SaleDocSevices[updateComponent.Servicesid].Item2;

                    model.SaleDocSevices.Remove(updateComponent.Servicesid);
                }
                context.SaveChanges();
            }

            // добавили новые
            foreach (var pc in model.SaleDocSevices)
            {
                context.Saleservices.Add(new Saleservices
                {
                    Saledocsid = saledocs.Saledocsid,
                    Servicesid = pc.Key,
                    Number = pc.Value.Item2
                });
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    MessageBox.Show(e?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return saledocs;
        }
    }
}
