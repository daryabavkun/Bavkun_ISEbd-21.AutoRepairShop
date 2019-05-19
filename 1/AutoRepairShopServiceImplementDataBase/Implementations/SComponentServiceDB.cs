﻿using System;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopServiceImplementDataBase;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class SComponentServiceDB : ISComponent
    {
        private AutoRepairShopDbContext context;
        public SComponentServiceDB(AutoRepairShopDbContext context)
        {
            this.context = context;
        }
        public List<SComponentView> GetList()
        {
            List<SComponentView> result = context.Components.Select(rec => new SComponentView
            {
                Id = rec.Id,
                ComponentName = rec.ComponentName
            })
            .ToList();
            return result;
        }
        public SComponentView GetElement(int id)
        {
            SComponent element = context.Components.FirstOrDefault(rec => rec.Id == id);
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
            SComponent element = context.Components.FirstOrDefault(rec => rec.ComponentName
            == model.ComponentName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Components.Add(new SComponent
            {
                ComponentName = model.ComponentName
            });
            context.SaveChanges();
        }
        public void UpdElement(SComponentBinding model)
        {
            SComponent element = context.Components.FirstOrDefault(rec => rec.ComponentName
           == model.ComponentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ComponentName = model.ComponentName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            SComponent element = context.Components.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Components.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
