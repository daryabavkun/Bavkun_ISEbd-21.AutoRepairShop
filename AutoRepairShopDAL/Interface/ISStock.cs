using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;

namespace AutoRepairShopDAL.Interface
{
    public interface ISStock
    {
        List<SStockView> GetList();
        SStockView GetElement(int id);
        void AddElement(SStockBinding model);
        void UpdElement(SStockBinding model);
        void DelElement(int id);
    }
}
