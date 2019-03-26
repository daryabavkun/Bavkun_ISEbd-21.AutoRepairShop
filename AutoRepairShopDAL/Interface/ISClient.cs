using System;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.Interface
{
    public interface ISClient
    {
        List<SClientView> GetList();
        SClientView GetElement(int id);
        void AddElement(SClientBinding model);
        void UpdElement(SClientBinding model);
        void DelElement(int id);
    }
}
