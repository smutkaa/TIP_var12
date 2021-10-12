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
    public partial class FormSubdivision : Form
    {
        public int Id { set { id = value; } }
        private readonly SubdivisionLogic logicS;
        private readonly AccountChartLogic logicAC;
        private int? id;
        public FormSubdivision(SubdivisionLogic logicS, AccountChartLogic logicAC)
        {
            InitializeComponent();
            this.logicS = logicS;
            this.logicAC = logicAC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAccountChart.SelectedValue == null)
            {
                MessageBox.Show("Выберите счет учета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicS.CreateOrUpdate(new SubdivisionBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Accountchartid = Convert.ToInt32(comboBoxAccountChart.SelectedValue),
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormSubdivision_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logicS.Read(new SubdivisionBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;

                        LoadComboBox(view);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadComboBox(null);
            }
        }
        private void LoadComboBox(SubdivisionViewModel view)
        {
            List<AccountingChartViewModel> list = logicAC.Read(null);
            if (list != null)
            {
                comboBoxAccountChart.DisplayMember = "Name";
                comboBoxAccountChart.ValueMember = "Id";
                comboBoxAccountChart.DataSource = list;
				if (view != null)
				{
                    comboBoxAccountChart.SelectedValue = list.FirstOrDefault(c => c.Id == view?.Accountchartid)?.Id;
                }
                
            }
        }
    }
}
