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
			currentContainer.RegisterType<ICars, CarStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<ICustomer, CustomerStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<IProvider, ProviderStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<IService, ServiceStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<ISubdivision, SubdivisionStorage>(new
			HierarchicalLifetimeManager());
			currentContainer.RegisterType<IPurchaseDoc, PurchaseDocStorage>(new
			HierarchicalLifetimeManager());
	


			currentContainer.RegisterType<AccountChartLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<SeriesLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<CarLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<CustomerLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ProviderLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ServiceLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<SubdivisionLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<PurchaseDocLogic>(new HierarchicalLifetimeManager());

			return currentContainer;
		}
	}
    
}
