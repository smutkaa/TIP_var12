using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12Database.Implements
{
    public class CustomerStorage: ICustomer
    {
        public List<CustomerViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Customers.Select(rec => new CustomerViewModel
                {
                    Id = rec.Customerid,
                    Fio = rec.Fio
                })
                .ToList();
            }
        }
        public CustomerViewModel GetElement(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var customer = context.Customers
               .FirstOrDefault(rec => rec.Fio == model.Fio || rec.Customerid == model.Id);
                return customer != null ?
                new CustomerViewModel
                {
                    Id = customer.Customerid,
                    Fio = customer.Fio
                } : null;
            }
        }
        public void Insert(CustomerBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Customers customer = CreateModel(model, new Customers());
                        context.Customers.Add(customer);
                        context.SaveChanges();
                        customer = CreateModel(model, customer, context);

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
        public void Update(CustomerBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Customers.FirstOrDefault(rec => rec.Customerid == model.Id);
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
        public void Delete(CustomerBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Customers element = context.Customers.FirstOrDefault(rec => rec.Customerid == model.Id);
                if (element != null)
                {
                    context.Customers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Customers CreateModel(CustomerBindingModel model, Customers customer)
        {
            customer.Fio = model.Fio;
            return customer;
        }

        private Customers CreateModel(CustomerBindingModel model, Customers customer, mydbContext context)
        {
            customer.Fio = model.Fio;
            return customer;
        }
    }
}
