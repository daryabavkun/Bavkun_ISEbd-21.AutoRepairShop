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

namespace AutoRepairShopImplementList.Implementation
{
    public class SClientServiceList : ISClient
    {
        private DataListSingleton source;
        public SClientServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SClientView> GetList()
        {
            List<SClientView> result = source.Clients.Select(rec => new SClientView
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO
            })
 .ToList();
            return result;
        }
        public SClientView GetElement(int id)
        {
            SClient element = source.Clients.FirstOrDefault(rec => rec.Id == id);
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
            SClient element = source.Clients.FirstOrDefault(rec => rec.ClientFIO ==
           model.ClientFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
            source.Clients.Add(new SClient
            {
                Id = maxId + 1,
                ClientFIO = model.ClientFIO
            });
        }
        public void UpdElement(SClientBinding model)
        {
            SClient element = source.Clients.FirstOrDefault(rec => rec.ClientFIO ==
           model.ClientFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ClientFIO = model.ClientFIO;
        }
        public void DelElement(int id)
        {
            SClient element = source.Clients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Clients.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}