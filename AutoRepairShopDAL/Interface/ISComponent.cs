using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.Interface
{
    public interface ISComponent
    {
        List<SComponentView> GetList();
        SComponentView GetElement(int id);
        void AddElement(SComponentBinding model);
        void UpdElement(SComponentBinding model);
        void DelElement(int id);
    }
}
