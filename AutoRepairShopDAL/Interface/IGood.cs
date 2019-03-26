using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.Interface
{
    public interface IGood
    {
        List<GoodView> GetList();
        GoodView GetElement(int id);
        void AddElement(GoodBinding model);
        void UpdElement(GoodBinding model);
        void DelElement(int id);
    }
}
