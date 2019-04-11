using System;
using AutoRepairShop;
using AutoRepairShopServiceImplementDataBase;
using AutoRepairShopServiceImplementDataBase.Implementations;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopImplementList.Implementation;
using AutoRepairShopImplement.Implementation;

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
            currentContainer.RegisterType<DbContext, AutoRepairDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISClient, SClientServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISComponent, SComponentServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGood, GoodServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMain, MainServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISStock, SStockServiceList>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
