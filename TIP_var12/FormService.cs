﻿using System;
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
    public partial class FormService : Form
    {
        public int Id { set { id = value; } }
        private readonly ServiceLogic logicSer;
        private readonly SubdivisionLogic logicSub;
        private int? id;
        public FormService(ServiceLogic logicSer, SubdivisionLogic logicSub)
        {
            InitializeComponent();
            this.logicSer = logicSer;
            this.logicSub = logicSub;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPrice.Text) || string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните пустые поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSubs.SelectedValue == null)
            {
                MessageBox.Show("Выберите подразделение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicSer.CreateOrUpdate(new ServiceBindingModel
                {
                    Name = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    Subdivisionid = Convert.ToInt32(comboBoxSubs.SelectedValue),
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

        private void FormService_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logicSer.Read(new ServiceBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxPrice.Text = view.Price;
                        LoadComboBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadComboBox();
            }
        }
        private void LoadComboBox()
        {
            List<SubdivisionViewModel> list = logicSub.Read(null);
            if (list != null)
            {
                comboBoxSubs.DisplayMember = "Name";
                comboBoxSubs.ValueMember = "Id";
                comboBoxSubs.DataSource = list;
                comboBoxSubs.SelectedItem = null;
            }
        }
    }
}