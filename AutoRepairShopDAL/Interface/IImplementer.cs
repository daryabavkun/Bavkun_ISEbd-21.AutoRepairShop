using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;

namespace AutoRepairShopDAL.Interface
{
    public interface IImplementer
    {
        List<ImplementerView> GetList();
        ImplementerView GetElement(int id);
        void AddElement(ImplementerBinding model);
        void UpdElement(ImplementerBinding model);
        void DelElement(int id);
        ImplementerView GetFreeWorker();
    }
}
