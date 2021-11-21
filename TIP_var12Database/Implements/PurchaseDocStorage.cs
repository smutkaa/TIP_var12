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
    public class PurchaseDocStorage: IPurchaseDoc
    {
        public List<PurchasedocsViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Purchasedocs
                    .Include(rec => rec.Car)
                    .Select(rec => new PurchasedocsViewModel
                {
                    Id = rec.Purchasedocid,
                    Date =rec.Date,
                    Quantity = rec.Quantity,
                    CarName = rec.Car.Name,
                    ProviderName = rec.Provider.Name,
                    Carid = rec.Carid,
                    Providerid = rec.Providerid,
                })
                .ToList();
            }
        }
        public List<PurchasedocsViewModel> GetFilteredList(PurchasedocsBindingModel model)
        {
            using (var context = new mydbContext())
            {
                return context.Purchasedocs
                    .Where(rec => rec.Providerid == model.Providerid || rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                    .Select(rec => new PurchasedocsViewModel
                    {
                        Id = rec.Purchasedocid,
                        Date = rec.Date,
                        Quantity = rec.Quantity,
                        CarName = rec.Car.Name,
                        ProviderName = rec.Provider.Name,
                        Carid = rec.Carid,
                        Providerid = rec.Providerid,
                    })
                .ToList();
            }
        }
        public PurchasedocsViewModel GetElement(PurchasedocsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var doc = context.Purchasedocs
                    
                .FirstOrDefault(rec => rec.Purchasedocid == model.Id);
                return doc != null ?
                new PurchasedocsViewModel
                {
                    Id = doc.Purchasedocid,
                    Date = doc.Date,
                    Quantity = doc.Quantity,
                    Carid = doc.Carid,
                    Providerid = doc.Providerid,
                } : null;
            }
        }
        public int Insert(PurchasedocsBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Purchasedocs doc = CreateModel(model, new Purchasedocs());
                        context.Purchasedocs.Add(doc);
                        context.SaveChanges();
                        doc = CreateModel(model, doc, context);

                        transaction.Commit();
                        Purchasedocs element = context.Purchasedocs.FirstOrDefault(rec => rec.Purchasedocid == doc.Purchasedocid);
                        return element.Purchasedocid;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(PurchasedocsBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Purchasedocs.FirstOrDefault(rec => rec.Purchasedocid == model.Id);
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
        public void Delete(PurchasedocsBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Purchasedocs element = context.Purchasedocs.FirstOrDefault(rec => rec.Purchasedocid ==model.Id);
                if (element != null)
                {
                    context.Purchasedocs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Purchasedocs CreateModel(PurchasedocsBindingModel model, Purchasedocs doc)
        {
            doc.Date = model.Date;
            doc.Quantity = model.Quantity;
            doc.Carid = model.Carid;
            doc.Providerid = model.Providerid;
            return doc;
        }

        private Purchasedocs CreateModel(PurchasedocsBindingModel model, Purchasedocs doc, mydbContext context)
        {
            doc.Date = model.Date;
            doc.Quantity = model.Quantity;
            doc.Carid = model.Carid;
            doc.Providerid = model.Providerid;

            return doc;
        }
    }
}
