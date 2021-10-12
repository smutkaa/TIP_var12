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
    public class CarStorage : ICars
    {
        public List<CarsViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Cars.Select(rec => new CarsViewModel
                {
                    Id = rec.Carid,
                    Name = rec.Name,
                    Purchaseprice = rec.Purchaseprice,
                    Retailprice = rec.Retailprice,
                    Seriesid = rec.Seriesid,
                    SeriesName = rec.Series.Name
                })
                .ToList();
            }
        }
        public CarsViewModel GetElement(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var cars = context.Cars
               .Include(rec => rec.Series)
               .FirstOrDefault(rec => rec.Name == model.Name || rec.Carid == model.Id );
                return cars != null ?
                new CarsViewModel
                {
                    Id = cars.Carid,
                    Name = cars.Name,
                    Purchaseprice = cars.Purchaseprice,
                    Retailprice = cars.Retailprice,
                    Seriesid = cars.Seriesid,
                    SeriesName = cars.Series.Name
                } : null;
            }
        }
        public void Insert(CarBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Cars cars = CreateModel(model, new Cars());
                        context.Cars.Add(cars);
                        context.SaveChanges();
                        cars = CreateModel(model, cars, context);

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
        public void Update(CarBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Cars.FirstOrDefault(rec => rec.Carid == model.Id);
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
        public void Delete(CarBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Cars element = context.Cars.FirstOrDefault(rec => rec.Carid ==
               model.Id);
                if (element != null)
                {
                    context.Cars.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Cars CreateModel(CarBindingModel model, Cars cars)
        {
            //cars.Carid = model.Id.Value;
            cars.Name = model.Name;
            cars.Purchaseprice = model.Purchaseprice.Value;
            cars.Retailprice = model.Retailprice.Value;
            cars.Seriesid = model.Seriesid;
            return cars;
        }

        private Cars CreateModel(CarBindingModel model, Cars cars, mydbContext context)
        {
            //cars.Carid = model.Id.Value;
            cars.Name = model.Name;
            cars.Purchaseprice = model.Purchaseprice.Value;
            cars.Retailprice = model.Retailprice.Value;
            cars.Seriesid = model.Seriesid;
            return cars;
        }
    }
}
