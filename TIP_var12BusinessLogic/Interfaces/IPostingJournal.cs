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
        List<ReportCarsViewModel> GetReportList(PostingJournalBindingModel model);
        List<PostingJournalBindingModel> GetDocumentNotes(PostingJournalBindingModel model);
        List<PostingJournalBindingModel> GetPay(PostingJournalBindingModel model);

        PostingJournalViewModel GetElement(PostingJournalBindingModel model);
        PostingJournalViewModel GetElementUpdate(PostingJournalBindingModel model);

        void Insert(PostingJournalBindingModel model);
        void Update(PostingJournalBindingModel model);
        void Delete(PostingJournalBindingModel model);
    }
}
