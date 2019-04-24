using System;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopImplementList.Implementation;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using AutoRepairShopImplement.Implementation;
using System.Data.Entity;
using AutoRepairShopServiceImplementDataBase;
using AutoRepairShopServiceImplementDataBase.Implementations;

namespace AutoRepairShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormAutoRepairShop>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AutoRepairShopDbContext>(new
HierarchicalLifetimeManager());

            currentContainer.RegisterType<ISClient, SClientServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISComponent, SComponentServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGood, GoodServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMain, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISStock, SStockServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
