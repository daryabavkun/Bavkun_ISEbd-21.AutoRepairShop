using System;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopImplement;

namespace AutoRepairShopImplement.Implementation
{
    public class SComponentServiceList : ISComponent
    {
        private DataListSingleton source;
        public SComponentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SComponentView> GetList()
        {
            List<SComponentView> result = new List<SComponentView>();
            for (int i = 0; i < source.Components.Count; ++i)
            {
                result.Add(new SComponentView
                {
                    Id = source.Components[i].Id,
                    ComponentName = source.Components[i].ComponentName
                });
            }
            return result;
        }
        public SComponentView GetElement(int id)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == id)
                {
                    return new SComponentView
                    {
                        Id = source.Components[i].Id,
                        ComponentName = source.Components[i].ComponentName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SComponentBinding model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id > maxId)
                {
                    maxId = source.Components[i].Id;
                }
                if (source.Components[i].ComponentName == model.ComponentName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            source.Components.Add(new SComponent
            {
                Id = maxId + 1,
                ComponentName = model.ComponentName
            });
        }
        public void UpdElement(SComponentBinding model)
        {
            int index = -1;
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Components[i].ComponentName == model.ComponentName &&
                source.Components[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Components[index].ComponentName = model.ComponentName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == id)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
