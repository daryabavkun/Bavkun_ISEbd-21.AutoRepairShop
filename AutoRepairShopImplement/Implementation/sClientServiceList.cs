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
            List<SClientView> result = new List<SClientView>();
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                result.Add(new SClientView
                {
                    Id = source.Clients[i].Id,
                    ClientFIO = source.Clients[i].ClientFIO
                });
            }
            return result;
        }
        public SClientView GetElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    return new SClientView
                    {
                        Id = source.Clients[i].Id,
                        ClientFIO = source.Clients[i].ClientFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SClientBinding model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id > maxId)
                {
                    maxId = source.Clients[i].Id;
                }
                if (source.Clients[i].ClientFIO == model.ClientFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Clients.Add(new SClient
            {
                Id = maxId + 1,
                ClientFIO = model.ClientFIO
            });
        }
        public void UpdElement(SClientBinding model)
        {
            int index = -1;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Clients[i].ClientFIO == model.ClientFIO &&
                source.Clients[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Clients[index].ClientFIO = model.ClientFIO;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
