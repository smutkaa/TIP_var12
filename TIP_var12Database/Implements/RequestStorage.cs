using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12Database.Implements
{
    public class RequestStorage : IRequest
    {
        public List<RequestViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Requests
                    .Include(rec => rec.Car)
                    .Select(rec => new RequestViewModel
                    {
                        Id = rec.Requestsid,
                        Date = rec.Date,
                        Quantity = rec.Quantity,
                        Carid = rec.Carid,
                        CarName = rec.Car.Name,
                        Customerid = rec.Customerid,
                        CustomerName = rec.Customer.Fio
                    })
                .ToList();
            }
        }
      
        public RequestViewModel GetElement(RequestBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var doc = context.Requests
                .FirstOrDefault(rec => rec.Requestsid == model.Id);
                return doc != null ?
                new RequestViewModel
                {
                    Id = doc.Requestsid,
                    Date = doc.Date,
                    Quantity = doc.Quantity,
                    Carid = doc.Carid,
                    CarName = doc.Car.Name,
                    Customerid = doc.Customerid,
                    CustomerName = doc.Customer.Fio
                } : null;
            }
        }
        public void Insert(RequestBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Requests doc = CreateModel(model, new Requests());
                        context.Requests.Add(doc);
                        context.SaveChanges();
                        doc = CreateModel(model, doc, context);

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
        public void Update(RequestBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Requests.FirstOrDefault(rec => rec.Requestsid == model.Id);
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
        public void Delete(RequestBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Requests element = context.Requests.FirstOrDefault(rec => rec.Requestsid == model.Id);
                if (element != null)
                {
                    context.Requests.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Requests CreateModel(RequestBindingModel model, Requests requests)
        {
            requests.Date = model.Date;
            requests.Quantity = model.Quantity;
            requests.Carid = model.Carid;
            requests.Customerid = model.Customerid;
            return requests;
        }

        private Requests CreateModel(RequestBindingModel model, Requests doc, mydbContext context)
        {
            doc.Date = model.Date;
            doc.Quantity = model.Quantity;
            doc.Carid = model.Carid;
            doc.Customerid = model.Customerid;

            return doc;
        }
    }
}
