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
    }
}
