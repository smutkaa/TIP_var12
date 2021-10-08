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
using Unity;

namespace TIP_var12
{
    public partial class FormCars : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly CarLogic _logicC;
        public FormCars(CarLogic logicC)
        {
            InitializeComponent();
            _logicC = logicC;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCar>();
            form.ShowDialog();
        }

        private void FormCars_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicC.Read(null);
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
