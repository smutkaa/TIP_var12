using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIP_var12BusinessLogic.BindingModel;
using TIP_var12BusinessLogic.BusinessLogic;
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12
{
    public partial class FormCar : Form
    {
        public int Id { set { id = value; } }
        private readonly CarLogic logicC;
        private readonly SeriesLogic logicS;
        private int? id;
        public FormCar(CarLogic logic, SeriesLogic logicS)
        {
            InitializeComponent();
            this.logicC = logic;
            this.logicS = logicS;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.Match(textBoxPurchasePrice.Text, @"^(\d+),(\d{1,2})$", RegexOptions.IgnoreCase).Success)
            {
                MessageBox.Show("Введите правильную закупочную цену(2 знака после запятой)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.Match(textBoxRetailPrice.Text, @"^(\d+),(\d{1,2})$", RegexOptions.IgnoreCase).Success)
            {
                MessageBox.Show("Введите правильную розничную цену(2 знака после запятой)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSeries.SelectedValue == null)
            {
                MessageBox.Show("Выберите серию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicC.CreateOrUpdate(new CarBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Purchaseprice = Convert.ToDecimal(textBoxPurchasePrice.Text),
                    Retailprice = Convert.ToDecimal(textBoxRetailPrice.Text),
                    Seriesid = Convert.ToInt32(comboBoxSeries.SelectedValue),
                }); ;
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

        private void FormCar_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logicC.Read(new CarBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;

                        textBoxPurchasePrice.Text = Convert.ToString(view.Purchaseprice);
                        textBoxRetailPrice.Text = Convert.ToString(view.Retailprice);
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
        private void LoadComboBox(CarsViewModel view)
        {
            List<SeriesViewModel> serieslist = logicS.Read(null);
            if (serieslist != null)
            {
                comboBoxSeries.DisplayMember = "Name";
                comboBoxSeries.ValueMember = "Id";
                comboBoxSeries.DataSource = serieslist;
                if (view != null)
                {
                    comboBoxSeries.SelectedValue = serieslist.FirstOrDefault(c => c.Id == view?.Seriesid)?.Id;
                }
            }
        }
    }
}
