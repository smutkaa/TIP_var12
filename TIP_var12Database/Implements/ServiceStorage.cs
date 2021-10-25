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
    public class ServiceStorage: IService
    {
        public List<ServiceViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Services.Select(rec => new ServiceViewModel
                {
                    Id = rec.Servicesid,
                    Name = rec.Name,
                    Price = rec.Price,
                    Subdivisionid = rec.Subdivisionid,
                    SubvisionName = rec.Subdivision.Name
                })
                .ToList();
            }
        }
        public List<ServiceViewModel> GetFilteredList(ServiceBindingModel model)
        {
            using (var context = new mydbContext())
            {
                return context.Services
                    .Where(rec=> rec.Subdivisionid == model.Subdivisionid)
                    .Select(rec => new ServiceViewModel
                {
                    Id = rec.Servicesid,
                    Name = rec.Name,
                    Price = rec.Price,
                    Subdivisionid = rec.Subdivisionid,
                    SubvisionName = rec.Subdivision.Name
                })
                .ToList();
            }
        }
        public ServiceViewModel GetElement(ServiceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var services = context.Services
                    .Include(rec=> rec.Subdivision)
                    .FirstOrDefault(rec => rec.Name == model.Name || rec.Servicesid == model.Id);
                return services != null ?
                new ServiceViewModel
                {
                    Id = services.Servicesid,
                    Name = services.Name,
                    Price = services.Price,
                    Subdivisionid = services.Subdivisionid,
                    SubvisionName = services.Subdivision.Name
                } : null;
            }
        }
        public void Insert(ServiceBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Services service = CreateModel(model, new Services());
                        context.Services.Add(service);
                        context.SaveChanges();
                        service = CreateModel(model, service, context);

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
        public void Update(ServiceBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Services.FirstOrDefault(rec => rec.Servicesid == model.Id);
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
        public void Delete(ServiceBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Services element = context.Services.FirstOrDefault(rec => rec.Servicesid ==
               model.Id);
                if (element != null)
                {
                    context.Services.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Services CreateModel(ServiceBindingModel model, Services service)
        {
            service.Name = model.Name;
            service.Price = model.Price;
            service.Subdivisionid = model.Subdivisionid;
            return service;
        }

        private Services CreateModel(ServiceBindingModel model, Services service, mydbContext context)
        {
            service.Name = model.Name;
            service.Price = model.Price;
            service.Subdivisionid = model.Subdivisionid;
            return service;
        }
    }
}
