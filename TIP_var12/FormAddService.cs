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
using TIP_var12BusinessLogic.ViewModels;

namespace TIP_var12
{
	public partial class FormAddService : Form
	{
		private readonly ServiceLogic logicS;
		public int Id { get { return Convert.ToInt32(comboBox1.SelectedValue); } set { comboBox1.SelectedValue = value; } }
		public string ServiceName { get { return comboBox1.Text; } }
		public int Count { get { return Convert.ToInt32(textBox1.Text); } set { textBox1.Text = value.ToString(); } }

		public FormAddService(ServiceLogic logicS)
		{
			InitializeComponent();
			this.logicS = logicS;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBox1.SelectedValue == null)
			{
				MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FormAddService_Load(object sender, EventArgs e)
		{
			List<ServiceViewModel> serlist = logicS.Read(null);

			if (serlist != null)
			{
				comboBox1.DisplayMember = "Name";
				comboBox1.ValueMember = "Id";
				comboBox1.DataSource = serlist;
			}
		}
	}
}
