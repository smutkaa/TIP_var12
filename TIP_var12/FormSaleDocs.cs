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
using Unity;

namespace TIP_var12
{
    public partial class FormSaleDocs : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly SaleDocLogic _logicC;

        public FormSaleDocs(SaleDocLogic _logicC)
        {
            InitializeComponent();
            this._logicC = _logicC;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSaleDoc>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

		private void FormSaleDocs_Load(object sender, EventArgs e)
		{
            LoadData();
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
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void buttonChange_Click(object sender, EventArgs e)
		{
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSaleDoc>();
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
                        _logicC.Delete(new SaleDocBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

		private void buttonFiltred_Click(object sender, EventArgs e)
		{
            try
            {
               
                var listFilt = _logicC.Read(new SaleDocBindingModel {  DateFrom = dateTimePickerFrom.Value, DateTo = dateTimePickerTo.Value });
                
                if (listFilt != null)
                {
                    dataGridView1.DataSource = listFilt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
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
