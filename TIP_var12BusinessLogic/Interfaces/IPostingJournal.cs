using System;
using System.Collections.Generic;
using System.Text;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12BusinessLogic.Interfaces
{
    public interface IPostingJournal
    {
        List<PostingJournalViewModel> GetFullList();
        List<PostingJournalViewModel> GetFilteredList(PostingJournalBindingModel model);
        PostingJournalViewModel GetElement(PostingJournalBindingModel model);

    }
}
