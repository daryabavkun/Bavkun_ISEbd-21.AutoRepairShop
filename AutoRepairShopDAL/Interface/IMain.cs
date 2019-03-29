using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.Interface
{
    public interface IMain
    {
        List<SOrderView> GetList();
        void CreateOrder(SOrderBinding model);
        void TakeOrderInWork(SOrderBinding model);
        void FinishOrder(SOrderBinding model);
        void PayOrder(SOrderBinding model);
        void PutComponentOnStock(SStockComponentBinding model);
    }
}
