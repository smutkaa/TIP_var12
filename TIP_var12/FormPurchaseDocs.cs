using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.BusinessLogic;
using TIP_var12BusinessLogic.ViewModels;
using Unity;

namespace TIP_var12
{
    public partial class FormPurchaseDocs : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PurchaseDocLogic _logicC;
        private readonly ProviderLogic _logicProv;

        public FormPurchaseDocs(PurchaseDocLogic _logicC, ProviderLogic _logicProv)
        {
            InitializeComponent();
            this._logicC = _logicC;
            this._logicProv = _logicProv;
        }
        private void FormPurchaseDocs_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPurchaseDoc>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPurchaseDoc>();
                form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logicC.Delete(new PurchasedocsBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void LoadData()
        {
            try
            {
                var list = _logicC.Read(null);
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                }
                List<ProviderViewModel> provlist = _logicProv.Read(null);

                if (provlist != null)
                {
                    comboBoxProvider.DisplayMember = "Name";
                    comboBoxProvider.ValueMember = "Id";
                    comboBoxProvider.DataSource = provlist;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFiltred_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBoxProvider.SelectedValue);
                List<PurchasedocsViewModel> listFilt;
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    listFilt = _logicC.Read(new PurchasedocsBindingModel { Providerid = id });
                }
                else if (checkBox2.Checked && !checkBox1.Checked)
                {
                    listFilt = _logicC.Read(new PurchasedocsBindingModel { DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });
                }
                else if (checkBox1.Checked && checkBox2.Checked)
                {
                    listFilt = _logicC.Read(null);
                }
                else
                {
                     listFilt = _logicC.Read(new PurchasedocsBindingModel {Providerid = id, DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value});
                }
               
                if (listFilt != null)
                {   
                    dataGridView1.DataSource = listFilt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
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
    }
}
