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
    public class PostingJournalStorage : IPostingJournal
    {
        public List<PostingJournalViewModel> GetFullList()
        {
            using (var context = new mydbContext())
            {
                return context.Postingjournal
                    .Select(rec => new PostingJournalViewModel
                {
                    Id = rec.Postingjournalid,
                    Date = rec.Date,
                    Debitaccount =rec.DebitaccountNavigation.Number,
                    Subcontodebit1 =rec.Subcontodebit1,
                    Subcontodebit2 = rec.Subcontodebit2,
                    Creditaccount = rec.CreditaccountNavigation.Number,
                    Subcontocredit1 =rec.Subcontocredit1,
                    Subcontocredit2 = rec.Subcontocredit2,
                        Count = rec.Count,
                        Total = rec.Total,
                    Saledocsid = rec.Saledocsid,
                    Purchasedocid = rec.Purchasedocid
                })
                .ToList();
            }
        }
        
        public List<PostingJournalViewModel> GetFilteredList(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new mydbContext())
            {
                return context.Postingjournal
                    .Where(rec => (rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                    ||
                    (rec.Saledocsid == model.Saledocsid && model.Saledocsid != null) || (rec.Purchasedocid == model.Purchasedocid && model.Purchasedocid != null)
                    ||
                    (rec.Debitaccount == model.Debitaccount && rec.Subcontodebit1 == model.Subcontodebit1)
                    || 
                    rec.Creditaccount == model.Creditaccount && rec.Subcontocredit1 == model.Subcontocredit1)
                    .Select(rec => new PostingJournalViewModel
                    {
                        Id = rec.Postingjournalid,
                        Date = rec.Date,
                        Debitaccount = rec.DebitaccountNavigation.Number,
                        Subcontodebit1 = rec.Subcontodebit1,
                        Subcontodebit2 = rec.Subcontodebit2,
                        Creditaccount = rec.CreditaccountNavigation.Number,
                        Subcontocredit1 = rec.Subcontocredit1,
                        Subcontocredit2 = rec.Subcontocredit2,
                        Count = rec.Count,
                        Total = rec.Total,
                        Saledocsid = rec.Saledocsid,
                        Purchasedocid = rec.Purchasedocid
                    })
                 .ToList();
            }
        }
        public List<PostingJournalBindingModel> GetDocumentNotes(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new mydbContext())
            {
                return context.Postingjournal
                    .Where(rec => (rec.Saledocsid == model.Saledocsid && model.Saledocsid != null) 
                    || (rec.Purchasedocid == model.Purchasedocid && model.Purchasedocid != null))
                    .Select(rec => new PostingJournalBindingModel
                    {
                        Id = rec.Postingjournalid,
                        Date = rec.Date,
                        Debitaccount = rec.DebitaccountNavigation.Number,
                        Subcontodebit1 = rec.Subcontodebit1,
                        Subcontodebit2 = rec.Subcontodebit2,
                        Creditaccount = rec.CreditaccountNavigation.Number,
                        Subcontocredit1 = rec.Subcontocredit1,
                        Subcontocredit2 = rec.Subcontocredit2,
                        Count = rec.Count,
                        Total = rec.Total,
                        Saledocsid = rec.Saledocsid,
                        Purchasedocid = rec.Purchasedocid
                    })
                 .ToList();
            }
        }
      
        public List<PostingJournalBindingModel> GetPay(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new mydbContext())
            {
                return context.Postingjournal
                    .Where(rec => rec.Saledocsid == model.Saledocsid && rec.Creditaccount == model.Creditaccount && rec.Debitaccount == model.Debitaccount)
                    .Select(rec => new PostingJournalBindingModel
                    {
                        Id = rec.Postingjournalid,
                        Total = rec.Total
                    })
                 .ToList();
            }
        }
        public PostingJournalViewModel GetElement(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var pj = context.Postingjournal
               .FirstOrDefault(rec => rec.Postingjournalid == model.Id || rec.Saledocsid == model.Saledocsid );
                return pj != null ?
                new PostingJournalViewModel
                {
                    Id = pj.Postingjournalid,
                    Debitaccount = pj.Debitaccount,
                    Subcontodebit1 = pj.Subcontodebit1,
                    Subcontodebit2 = pj.Subcontodebit2,
                    Creditaccount = pj.Creditaccount,
                    Subcontocredit1 = pj.Subcontocredit1,
                    Subcontocredit2 = pj.Subcontocredit2,
                    Count = pj.Count,
                    Total = pj.Total,
                    Saledocsid = pj.Saledocsid,
                    Purchasedocid = pj.Purchasedocid
                } : null;
            }
        }
        public PostingJournalViewModel GetElementUpdate(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new mydbContext())
            {
                var pj = context.Postingjournal
               .FirstOrDefault(rec => (rec.Purchasedocid == model.Purchasedocid || rec.Saledocsid == model.Saledocsid) && rec.Creditaccount== model.Creditaccount && rec.Debitaccount == model.Debitaccount);
                return pj != null ?
                new PostingJournalViewModel
                {
                    Id = pj.Postingjournalid,
                    Debitaccount = pj.Debitaccount,
                    Subcontodebit1 = pj.Subcontodebit1,
                    Subcontodebit2 = pj.Subcontodebit2,
                    Creditaccount = pj.Creditaccount,
                    Subcontocredit1 = pj.Subcontocredit1,
                    Subcontocredit2 = pj.Subcontocredit2,
                    Count = pj.Count,
                    Total = pj.Total,
                    Saledocsid = pj.Saledocsid,
                    Purchasedocid = pj.Purchasedocid
                } : null;
            }
        }
        public void Insert(PostingJournalBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Postingjournal pj = CreateModel(model, new Postingjournal());
                        context.Postingjournal.Add(pj);
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
        public void Update(PostingJournalBindingModel model)
        {
            using (var context = new mydbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Postingjournal.FirstOrDefault(rec => rec.Postingjournalid == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch(DbUpdateException ex)
                    {
                        MessageBox.Show(Convert.ToString(ex.InnerException), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PostingJournalBindingModel model)
        {
            using (var context = new mydbContext())
            {
                Postingjournal element = context.Postingjournal.FirstOrDefault(rec => rec.Postingjournalid == model.Id);
                if (element != null)
                {
                    context.Postingjournal.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Postingjournal CreateModel(PostingJournalBindingModel model, Postingjournal pj)
        {
            pj.Date = model.Date;
            pj.Debitaccount = model.Debitaccount;
            pj.Subcontodebit1 = model.Subcontodebit1;
            pj.Subcontodebit2 = model.Subcontodebit2;
            pj.Creditaccount = model.Creditaccount;
            pj.Subcontocredit1 = model.Subcontocredit1;
            pj.Subcontocredit2 = model.Subcontocredit2;
            pj.Count = model.Count;
            pj.Total = model.Total;
            pj.Saledocsid = model.Saledocsid;
            pj.Purchasedocid = model.Purchasedocid;
            pj.Comment = model.Comment;
            return pj;
        }
    }
}
