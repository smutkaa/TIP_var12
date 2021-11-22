using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    public class PostingJournalLogic
    {
        private readonly IPostingJournal _pjStorage;

        public PostingJournalLogic(IPostingJournal pjStorage)
        {
            _pjStorage = pjStorage;
        }

        public List<PostingJournalViewModel> Read(PostingJournalBindingModel model)
        {
            if (model == null)
            {
                return _pjStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PostingJournalViewModel> { _pjStorage.GetElement(model) };
            }
            return _pjStorage.GetFilteredList(model);
        }
        public List<PostingJournalBindingModel> ReadDel(PostingJournalBindingModel model)
        {
            if (model.Saledocsid != null && model.Creditaccount != 0 && model.Debitaccount != 0)
            {
                return _pjStorage.GetPay(model);
            }
            if (model.Purchasedocid != null || model.Saledocsid != null)
            {
                return _pjStorage.GetDocumentNotes(model);
            }
            return null;

        }
        public void CreateOrUpdate(PostingJournalBindingModel model)
        {
            var element = _pjStorage.GetElementUpdate(new PostingJournalBindingModel { Saledocsid = model.Saledocsid, Purchasedocid = model.Purchasedocid });
           
            if (element != null && (element.Purchasedocid != model.Purchasedocid || element.Saledocsid != model.Saledocsid))
            {
                throw new Exception("Не найдена такая операция");
            }
            if (model.Id.HasValue)
            {
                _pjStorage.Update(model);
            }
            else
            {
                _pjStorage.Insert(model);
            }
        }
        public void Delete(PostingJournalBindingModel model)
        {
            
            var elements = _pjStorage.GetDocumentNotes(new PostingJournalBindingModel
            {
                Purchasedocid = model.Purchasedocid,
                Saledocsid = model.Saledocsid
            });
            if (elements.Count == 0)
            {
                throw new Exception("Проводки по этому документу не найдены");
            }
            if(model.Creditaccount != 0)
            {
                foreach (var el in elements)
                {
                    _pjStorage.Delete(el);
                }
            }
           
        }
    }
}
