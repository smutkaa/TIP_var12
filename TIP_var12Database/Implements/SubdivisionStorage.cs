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
    public class SubdivisionStorage: ISubdivision
    {
        public List<SubdivisionViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Subdivision.Select(rec => new SubdivisionViewModel
                {
                    Id = rec.Subdivisionid,
                    Name = rec.Name,
                    Accountchartid = rec.Accountchartid,
                    AccountchartName = rec.Accountchart.Name
                })
                .ToList();
            }
        }
        public SubdivisionViewModel GetElement(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var subdivision = context.Subdivision
                    .Include(rec=> rec.Accountchart)
                    .FirstOrDefault(rec => rec.Name == model.Name || rec.Subdivisionid == model.Id);
                return subdivision != null ?
                new SubdivisionViewModel
                {
                    Id = subdivision.Subdivisionid,
                    Name = subdivision.Name,
                    Accountchartid = subdivision.Accountchartid,
                    AccountchartName = subdivision.Accountchart.Name
                } : null;
            }
        }
        public void Insert(SubdivisionBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Subdivision subdivision = CreateModel(model, new Subdivision());
                        context.Subdivision.Add(subdivision);
                        context.SaveChanges();
                        subdivision = CreateModel(model, subdivision, context);

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
        public void Update(SubdivisionBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Subdivision.FirstOrDefault(rec => rec.Subdivisionid == model.Id);
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
        public void Delete(SubdivisionBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Subdivision element = context.Subdivision.FirstOrDefault(rec => rec.Subdivisionid ==
               model.Id);
                if (element != null)
                {
                    context.Subdivision.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Subdivision CreateModel(SubdivisionBindingModel model, Subdivision subdivision)
        {
            subdivision.Name = model.Name;
            subdivision.Accountchartid = model.Accountchartid;
            return subdivision;
        }

        private Subdivision CreateModel(SubdivisionBindingModel model, Subdivision subdivision, mydbContext context)
        {
            subdivision.Name = model.Name;
            subdivision.Accountchartid = model.Accountchartid;
            return subdivision;
        }
    }
}
