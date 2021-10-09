using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace TIP_var12
{
	public partial class FormMain : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		public FormMain()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{

		}

		private void планСчетовToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormAccountCharts>();
			form.ShowDialog();
		}

        private void серияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSeries>();
            form.ShowDialog();
        }

        private void автомобилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCars>();
            form.ShowDialog();
        }

        private void поставщикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProviders>();
            form.ShowDialog();
        }

        private void покупательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void подразделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSubdivisions>();
            form.ShowDialog();
        }
    }
}
