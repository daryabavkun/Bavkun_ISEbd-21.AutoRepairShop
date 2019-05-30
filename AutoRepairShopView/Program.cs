using System;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            APIClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAutoRepairShop());
        }
    }
}
