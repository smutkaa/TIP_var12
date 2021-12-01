using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIP_var12BusinessLogic.BusinessLogic;
using Unity;
using TIP_var12BusinessLogic.ViewModels;
using TIP_var12BusinessLogic.BindingModel;

namespace TIP_var12
{
    public partial class FormPostingJournal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PostingJournalLogic _logicPJ;
        public int Id { set { id = value; } }
        private int? id;
        public string Document { set { doc = value; } }
        private string doc;
        public FormPostingJournal(PostingJournalLogic _logicPJ)
        {
            InitializeComponent();
            this._logicPJ = _logicPJ;
        }

        private void FormPostingJournal_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            if (id.HasValue)
            {
                List<PostingJournalViewModel> list = null;
                if (doc == "purchase")
                {
                    list = _logicPJ.Read(new PostingJournalBindingModel { Purchasedocid = id});
                }
                else if(doc == "sale")
                {
                    list = _logicPJ.Read(new PostingJournalBindingModel { Saledocsid = id });
                }
               
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                }
            }
            else
            {
                try
                {
                    var list = _logicPJ.Read(null);
                    if (list != null)
                    {
                        dataGridView1.DataSource = list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }
        private void buttonFiltred_Click(object sender, EventArgs e)
        {
            try
            {
                List<PostingJournalViewModel> listFilt;
                listFilt = _logicPJ.Read(new PostingJournalBindingModel { DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });

                if (listFilt != null)
                {
                    dataGridView1.DataSource = listFilt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonDocument_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.SelectedRows[0].Cells[10].Value != null)
                {
                    var form = Container.Resolve<FormSaleDoc>();
                    form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[10].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (dataGridView1.SelectedRows[0].Cells[11].Value != null)
                {
                    var form = Container.Resolve<FormPurchaseDoc>();
                    form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[11].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                
            }
        }
    }
}
