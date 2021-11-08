﻿using Microsoft.EntityFrameworkCore;
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
using TIP_var12Database;
using Unity;

namespace TIP_var12
{
	public partial class FormSaleDoc : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { id = value; } }
		private int? id;

		private readonly SaleDocLogic logicSD;
		private readonly RequestLogiccs logicReq;

		private Dictionary<int, (string, int)> saleDocServices;

		public FormSaleDoc(SaleDocLogic logicSD, RequestLogiccs logicReq)
		{
			InitializeComponent();
			this.logicSD = logicSD;
			this.logicReq = logicReq;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (dateTimePicker.Value == null)
			{
				MessageBox.Show("Укажите Дату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxRequest.SelectedItem == null)
			{
				MessageBox.Show("Выберите заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxFIO.Text))
			{
				MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DateTime? dateReq = logicReq.Read(new RequestBindingModel { Id = Convert.ToInt32(comboBoxRequest.SelectedValue)})?[0].Date;
			if (dateReq > dateTimePicker.Value)
			{
				MessageBox.Show("Дата заявки не может быть больше даты в документе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				logicSD.CreateOrUpdate(new SaleDocBindingModel
				{
					Id = id,
					Date = dateTimePicker.Value,
					Requestsid = Convert.ToInt32(comboBoxRequest.SelectedValue),
					Employee = textBoxFIO.Text,
					SaleDocSevices = saleDocServices,
					Total = RequestRemainder()

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
		private decimal RequestRemainder()
		{
			decimal price = 0; 
			
			var context = new mydbContext();
			var requests = context.Requests
				.Include(rec => rec.Car)
				.FirstOrDefault(rec => rec.Requestsid == Convert.ToInt32(comboBoxRequest.SelectedValue));
			price = requests.Quantity * requests.Car.Retailprice;

			foreach (var ser in saleDocServices)
			{
				price += context.Services.FirstOrDefault(rec => rec.Servicesid == ser.Key).Price * ser.Value.Item2;
			}

			return price;
		}
		
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormAddService>();

			if (form.ShowDialog() == DialogResult.OK)
			{
				try
				{
					saleDocServices.Add(form.Id, (form.ServiceName, form.Count));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				LoadData();
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{
						saleDocServices.Remove(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}

		private void FormSaleDoc_Load(object sender, EventArgs e)
		{
			LoadComboBox();
			if (id.HasValue)
			{
				try
				{
					SaleDocViewModel view = logicSD.Read(new SaleDocBindingModel { Id = id.Value })?[0];
					if (view != null)
					{
						dateTimePicker.Value = view.Date;
						comboBoxRequest.SelectedValue = view.Requestsid;
						textBoxFIO.Text = view.Employee;
						saleDocServices = view.SaleDocSevices;
						LoadData();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				saleDocServices = new Dictionary<int, (string, int)>();
			}
		}
		private void LoadData()
		{
			try
			{
				if (saleDocServices != null)
				{
					dataGridView1.Rows.Clear();
					foreach (var pc in saleDocServices)
					{
						dataGridView1.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void LoadComboBox()
		{
			List<RequestViewModel> reqlist = logicReq.Read(null);

			if (reqlist != null)
			{
				comboBoxRequest.DisplayMember = "Id";
				comboBoxRequest.ValueMember = "Id";
				comboBoxRequest.DataSource = reqlist;
			}
		}
	}
}
