using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIP_var12
{
    public partial class FormSeries : Form
    {
       // private readonly SeriesLogic _logicS;
        public FormSeries()
        {
            InitializeComponent();
        }

        private void FormSeries_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                //var view = _logicS.Read(null);
                //if (view != null)
                //{
                //    dataGridView.DataSource = view;
                //    dataGridView.Columns[0].Visible = false;
                //    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    private void buttonChange_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

     
    private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
