using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIP_var12BusinessLogic.BusinessLogic;
using TIP_var12BusinessLogic.Interfaces;
using TIP_var12Database.Implements;
using Unity;
using Unity.Lifetime;

namespace TIP_var12
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var container = BuildUnityContainer();
			new UnityContainer().AddExtension(new Diagnostic());
			Application.Run(container.Resolve<FormMain>());
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<IAccountingChart, AccountingChartStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<ISeries, SeriesStorage>(new
			HierarchicalLifetimeManager());


			currentContainer.RegisterType<AccountChartLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<SeriesLogic>(new HierarchicalLifetimeManager());

			return currentContainer;
		}
	}
    
}
