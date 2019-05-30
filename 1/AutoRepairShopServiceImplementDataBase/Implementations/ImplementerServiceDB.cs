using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class ImplementerServiceDB : IImplementer
    {
        private AutoRepairShopDbContext context;
        public ImplementerServiceDB(AutoRepairShopDbContext context)
        {
            this.context = context;
        }
        public List<ImplementerView> GetList()
        {
            List<ImplementerView> result = context.Implementers
            .Select(rec => new ImplementerView
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO
            })
            .ToList();
            return result;
        }
        public ImplementerView GetElement(int id)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                return new ImplementerView
                {
                    Id = element.Id,
                    ImplementerFIO = element.ImplementerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ImplementerBinding model)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec =>
           rec.ImplementerFIO == model.ImplementerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Implementers.Add(new Implementer
            {
                ImplementerFIO = model.ImplementerFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(ImplementerBinding model)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec =>
            rec.ImplementerFIO == model.ImplementerFIO &&
           rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
        element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ImplementerFIO = model.ImplementerFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public ImplementerView GetFreeWorker()
        {
            var ordersWorker = context.Implementers
            .Select(x => new
            {
                ImplId = x.Id,
                Count = context.SOrders.Where(o => o.Status == SOrderStatus.Выполняется
     && o.ImplementerId == x.Id).Count()
            })
            .OrderBy(x => x.Count)
            .FirstOrDefault();
            if (ordersWorker != null)
            {
                return GetElement(ordersWorker.ImplId);
            }
            return null;
        }
    }
}
