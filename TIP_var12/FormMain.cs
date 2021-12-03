using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
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
            var form = Container.Resolve<FormSubdivisions>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }

        private void документзакупкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPurchaseDocs>();
            form.ShowDialog();
        }

        private void заявкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }

        private void документToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSaleDocs>();
            form.ShowDialog();
        }

        private void журналПроводокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPostingJournal>();
            form.ShowDialog();
        }

        private void оборотносальдоваяПо41СчетуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportPJ>();
            form.ShowDialog();
        }

        private void выполненныеЗаявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void сменитьЯзыкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-hk");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-hk");

                Properties.Settings.Default.Language = "zh-hk";
                Properties.Settings.Default.Save();
                Application.Restart();

            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
                Properties.Settings.Default.Language = "ru-RU";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
}
