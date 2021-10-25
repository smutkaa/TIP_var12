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
    public partial class FormRequest : Form
    {
        public int Id { set { id = value; } }
        private readonly CarLogic logicC;
        private readonly CustomerLogic logicCus;
        private readonly RequestLogiccs logicR;
        private int? id;
        public FormRequest(CarLogic logicC, RequestLogiccs logicR , CustomerLogic logicCus)
        {
            InitializeComponent();
            this.logicC = logicC;
            this.logicR = logicR;
            this.logicCus = logicCus;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCout.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите автомобиль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicR.CreateOrUpdate(new RequestBindingModel
                {
                    Id = id,
                    Date = dateTimePicker.Value,
                    Carid = Convert.ToInt32(comboBoxCar.SelectedValue),
                    Customerid = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    Quantity = Convert.ToInt32(textBoxCout.Text)
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

        private void FormRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logicR.Read(new RequestBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxCout.Text = Convert.ToString(view.Quantity);
                        dateTimePicker.Value = view.Date;

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
        private void LoadComboBox(RequestViewModel view)
        {
            List<CarsViewModel> carslist = logicC.Read(null);
            List<CustomerViewModel> cuslist = logicCus.Read(null);

            if (carslist != null && cuslist != null)
            {
                comboBoxCar.DisplayMember = "Name";
                comboBoxCar.ValueMember = "Id";
                comboBoxCar.DataSource = carslist;
                if (view != null)
                {
                    comboBoxCar.SelectedValue = carslist.FirstOrDefault(c => c.Id == view?.Carid)?.Id;
                }

                comboBoxCustomer.DisplayMember = "FIO";
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DataSource = cuslist;
                if (view != null)
                {
                    comboBoxCustomer.SelectedValue = cuslist.FirstOrDefault(c => c.Id == view?.Customerid)?.Id;
                }
            }
        }
    }
}
