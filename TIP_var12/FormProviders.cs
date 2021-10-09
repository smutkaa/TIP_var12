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

namespace TIP_var12
{
    public partial class FormProviders : Form
    {
        private readonly ProviderLogic _logicP;
        public FormProviders(ProviderLogic _logicP)
        {
            InitializeComponent();
            this._logicP = _logicP;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                ProviderViewModel view = _logicP.Read(new ProvidersBindingModel { Id = id })?[0];
                if (view != null)
                {
                    textBoxProvider.Text = view.Name;
                    LoadData();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProvider.Text))
            {
                MessageBox.Show("Заполните поле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicP.CreateOrUpdate(new ProvidersBindingModel
                {
                    Name = textBoxProvider.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxProvider.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logicP.Delete(new ProvidersBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FormProviders_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logicP.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
