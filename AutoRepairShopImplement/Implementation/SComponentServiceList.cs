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
            List<SComponentView> result = source.Components.Select(rec => new SComponentView
            {
                Id = rec.Id,
                ComponentName = rec.ComponentName
            })
 .ToList();
            return result;
        }
        public SComponentView GetElement(int id)
        {
            SComponent element = source.Components.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SComponentView
                {
                    Id = element.Id,
                    ComponentName = element.ComponentName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SComponentBinding model)
        {
            SComponent element = source.Components.FirstOrDefault(rec => rec.ComponentName
           == model.ComponentName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            int maxId = source.Components.Count > 0 ? source.Components.Max(rec =>
           rec.Id) : 0;
            source.Components.Add(new SComponent
            {
                Id = maxId + 1,
                ComponentName = model.ComponentName
            });
        }
        public void UpdElement(SComponentBinding model)
        {
            SComponent element = source.Components.FirstOrDefault(rec => rec.ComponentName
           == model.ComponentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ComponentName = model.ComponentName;
        }
        public void DelElement(int id)
        {
            SComponent element = source.Components.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Components.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
