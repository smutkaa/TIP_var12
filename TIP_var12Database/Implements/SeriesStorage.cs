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
    public class SeriesStorage: ISeries
    {
        public List<SeriesViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Series.Select(rec => new SeriesViewModel
                {
                    Id = rec.Seriesid,
                    Name = rec.Name,
                })
                .ToList();
            }
        }
        public SeriesViewModel GetElement(SeriesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var  series= context.Series
               .FirstOrDefault(rec => rec.Name == model.Name || rec.Seriesid == model.Id);
                return series != null ?
                new SeriesViewModel
                {
                    Id = series.Seriesid,
                    Name = series.Name

                } : null;
            }
        }
        public void Insert(SeriesBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Series series = CreateModel(model, new Series());
                        context.Series.Add(series);
                        context.SaveChanges();
                        series = CreateModel(model, series, context);

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
        public void Update(SeriesBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Series.FirstOrDefault(rec => rec.Seriesid == model.Id);
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
        public void Delete(SeriesBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Series element = context.Series.FirstOrDefault(rec => rec.Seriesid ==
               model.Id);
                if (element != null)
                {
                    context.Series.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Series CreateModel(SeriesBindingModel model, Series series)
        {
            series.Name = model.Name;
            return series;
        }

        private Series CreateModel(SeriesBindingModel model, Series series, mydbContext context)
        {
            series.Name = model.Name;
            return series;
        }
    }
}
