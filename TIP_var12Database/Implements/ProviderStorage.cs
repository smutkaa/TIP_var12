using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12Database.Implements
{
    public class ProviderStorage : IProvider
    {
        public List<ProviderViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Providers.Select(rec => new ProviderViewModel
                {
                    Id = rec.Providerid,
                    Name = rec.Name
                })
                .ToList();
            }
        }
        public ProviderViewModel GetElement(ProvidersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var prov = context.Providers
               .FirstOrDefault(rec => rec.Name == model.Name);
                return prov != null ?
                new ProviderViewModel
                {
                    Id = prov.Providerid,
                    Name = prov.Name
                } : null;
            }
        }
        public void Insert(ProvidersBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Providers provider = CreateModel(model, new Providers());
                        context.Providers.Add(provider);
                        context.SaveChanges();
                        provider = CreateModel(model, provider, context);

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
        public void Update(ProvidersBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Providers.FirstOrDefault(rec => rec.Providerid == model.Id);
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
        public void Delete(ProvidersBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Providers element = context.Providers.FirstOrDefault(rec => rec.Providerid == model.Id);
                if (element != null)
                {
                    context.Providers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Providers CreateModel(ProvidersBindingModel model, Providers provider)
        {
            provider.Name = model.Name;
            return provider;
        }

        private Providers CreateModel(ProvidersBindingModel model, Providers provider, mydbContext context)
        {
            provider.Name = model.Name;
            return provider;
        }
    }
}
