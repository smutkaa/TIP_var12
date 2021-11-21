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
    public partial class FormPurchaseDoc : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private readonly CarLogic logicC;
        private readonly PurchaseDocLogic logicP;
        private readonly ProviderLogic logicProv;
        private readonly PostingJournalLogic logicPJ;
        private readonly AccountChartLogic  logicAC;
        private List<AccountingChartViewModel> listAC;


        public FormPurchaseDoc(CarLogic logicC , PurchaseDocLogic logicP, ProviderLogic logicProv, PostingJournalLogic logicPJ, AccountChartLogic logicAC)
        {
            InitializeComponent();
            this.logicC = logicC;
            this.logicP = logicP;
            this.logicProv = logicProv;
            this.logicPJ = logicPJ;
            this.logicAC = logicAC;
            listAC = logicAC.Read(null);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCout.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProvider.SelectedValue == null)
            {
                MessageBox.Show("Выберите поставщика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите автомобиль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Convert.ToDecimal(textBoxPurchasePrice.Text) >= Convert.ToDecimal(textBoxRetailPrice.Text))
            {
                MessageBox.Show("Розничная цена должна быть больше, чем закупочная", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var cars = logicC.Read(new CarBindingModel { Id = Convert.ToInt32(comboBoxCar.SelectedValue) })?[0];
                
                int code = logicP.CreateOrUpdate(new PurchasedocsBindingModel
                {
                    Id = id,
                    Date = dateTimePicker.Value,
                    Quantity = Convert.ToInt32(textBoxCout.Text),
                    Providerid = Convert.ToInt32(comboBoxProvider.SelectedValue),
                    Carid = Convert.ToInt32(comboBoxCar.SelectedValue),
                });
                
                logicC.CreateOrUpdate(new CarBindingModel
                {
                    Id = Convert.ToInt32(comboBoxCar.SelectedValue),
                    Name = cars.Name,
                    Purchaseprice = Convert.ToDecimal(textBoxPurchasePrice.Text),
                    Retailprice = Convert.ToDecimal(textBoxRetailPrice.Text),
                    Seriesid = cars.Seriesid
                });
                logicPJ.CreateOrUpdate(new PostingJournalBindingModel
                {
                    Date = dateTimePicker.Value,
                    Debitaccount = Convert.ToInt32(listAC.FirstOrDefault(a => a.Number == 41)?.Id),
                    Subcontodebit1 = cars.Name,
                    Subcontodebit2 = cars.SeriesName,
                    Creditaccount = Convert.ToInt32(listAC.FirstOrDefault(a => a.Number == 60)?.Id),
                    Subcontocredit1 = Convert.ToString(comboBoxProvider.Text),
                    Total = Convert.ToDecimal(textBoxCout.Text) * Convert.ToDecimal(textBoxPurchasePrice.Text),
                    Purchasedocid = code
                }) ;
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

        private void FormPurchaseDoc_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    var view = logicP.Read(new PurchasedocsBindingModel { Id = id })?[0];
                    var cars = logicC.Read(new CarBindingModel { Id = view.Carid })?[0];

                    if (view != null)
                    {
                        dateTimePicker.Value = view.Date;
                        textBoxCout.Text = Convert.ToString(view.Quantity);
                        textBoxPurchasePrice.Text = Convert.ToString(cars.Purchaseprice);
                        textBoxRetailPrice.Text = Convert.ToString(cars.Retailprice);

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
        private void LoadComboBox(PurchasedocsViewModel purchase)
        {
            List<ProviderViewModel> provlist = logicProv.Read(null);
            List<CarsViewModel> carlist = logicC.Read(null);

            if (provlist != null && carlist != null)
            {
                comboBoxCar.DisplayMember = "Name";
                comboBoxCar.ValueMember = "Id";
                comboBoxCar.DataSource = carlist;
                if (purchase != null)
                {
                    comboBoxCar.SelectedValue = carlist.FirstOrDefault(c => c.Id == purchase?.Carid)?.Id;
                }

                comboBoxProvider.DisplayMember = "Name";
                comboBoxProvider.ValueMember = "Id";
                comboBoxProvider.DataSource = provlist;
                if (purchase != null)
                {
                    comboBoxProvider.SelectedValue = provlist.FirstOrDefault(c => c.Id == purchase?.Providerid)?.Id;
                }
            }
        }
    }
}
