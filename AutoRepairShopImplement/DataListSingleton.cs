using AutoRepairShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<SClient> Clients { get; set; }
        public List<SComponent> Components { get; set; }
        public List<SOrder> Orders { get; set; }
        public List<Good> Products { get; set; }
        public List<GoodComponent> ProductComponents { get; set; }
        private DataListSingleton()
        {
            Clients = new List<SClient>();
            Components = new List<SComponent>();
            Orders = new List<SOrder>();
            Products = new List<Good>();
            ProductComponents = new List<GoodComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}