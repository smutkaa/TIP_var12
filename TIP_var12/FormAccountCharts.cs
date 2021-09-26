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

namespace TIP_var12
{
	public partial class FormAccountCharts : Form
	{
        private readonly AccountChartLogic _logicAC;
        public FormAccountCharts(AccountChartLogic logicAC)
		{
			InitializeComponent();

            _logicAC = logicAC;
        }

		private void AccountCharts_Load(object sender, EventArgs e)
		{
			LoadData();
		}
        private void LoadData()
        {
            try
            {
                var view = _logicAC.Read(null);
                if (view != null)
                {
                    dataGridView.DataSource = view;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        }
    }
