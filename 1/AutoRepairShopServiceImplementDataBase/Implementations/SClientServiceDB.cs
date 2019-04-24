using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class SClientServiceDB : ISClient
    {
        private AutoRepairShopDbContext context;
        public SClientServiceDB(AutoRepairShopDbContext context)
        {
            this.context = context;
        }
        public List<SClientView> GetList()
        {
            List<SClientView> result = context.Clients.Select(rec => new
           SClientView
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO
            })
            .ToList();
            return result;
        }
        public SClientView GetElement(int id)
        {
            SClient element = context.Clients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SClientView
                {
                    Id = element.Id,
                    ClientFIO = element.ClientFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SClientBinding model)
        {
            SClient element = context.Clients.FirstOrDefault(rec => rec.ClientFIO ==
           model.ClientFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Clients.Add(new SClient
            {
                ClientFIO = model.ClientFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(SClientBinding model)
        {
            SClient element = context.Clients.FirstOrDefault(rec => rec.ClientFIO ==
           model.ClientFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ClientFIO = model.ClientFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            SClient element = context.Clients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
