using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;

namespace AutoRepairShopDAL.Interface
{
    public interface IReport
    {
        void SaveProductPrice(ReportBinding model);
        List<SStocksLoadView> GetStocksLoad();
        void SaveStocksLoad(ReportBinding model);
        List<SClientOrders> GetClientOrders(ReportBinding model);
        void SaveClientOrders(ReportBinding model);
    }
}
