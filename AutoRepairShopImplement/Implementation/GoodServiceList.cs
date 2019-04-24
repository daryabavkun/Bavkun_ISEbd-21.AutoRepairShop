using System;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopImplement.Implementation
{
    public class GoodServiceList : IGood
    {
        private DataListSingleton source;
        public GoodServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<GoodView> GetList()
        {
            List<GoodView> result = source.Products.Select(rec => new GoodView
            {

                 Id = rec.Id,
                 ProductName = rec.ProductName,
                 Price = rec.Price,
                 ProductComponent = source.ProductComponents
                 .Where(recPC => recPC.ProductId == rec.Id)
                .Select(recPC => new GoodComponentView
                {
                    Id = recPC.Id,
                    ProductId = recPC.ProductId,
                    ComponentId = recPC.ComponentId,
                    ComponentName = source.Components.FirstOrDefault(recC =>
                    recC.Id == recPC.ComponentId)?.ComponentName,
                    Count = recPC.Count
                })
                .ToList()
            })
            .ToList();
            return result;
        }
        public GoodView GetElement(int id)
        {
            Good element = source.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GoodView
                {
                    Id = element.Id,
                    ProductName = element.ProductName,
                    Price = element.Price,
                    ProductComponent = source.ProductComponents
                .Where(recPC => recPC.ProductId == element.Id)
                .Select(recPC => new GoodComponentView
                {
                    Id = recPC.Id,
                    ProductId = recPC.ProductId,
                    ComponentId = recPC.ComponentId,
                    ComponentName = source.Components.FirstOrDefault(recC =>
     recC.Id == recPC.ComponentId)?.ComponentName,
                    Count = recPC.Count
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(GoodBinding model)
        {
            Good element = source.Products.FirstOrDefault(rec => rec.ProductName ==
           model.ProductName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Products.Count > 0 ? source.Products.Max(rec => rec.Id) :
           0;
            source.Products.Add(new Good
            {
                Id = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.ProductComponents.Count > 0 ?
           source.ProductComponents.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.ProductComponents
            .GroupBy(rec => rec.ComponentId)
           .Select(rec => new
           {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.ProductComponents.Add(new GoodComponent
                {
                    Id = ++maxPCId,
                    ProductId = maxId + 1,
                    ComponentId = groupComponent.ComponentId,
                    Count = groupComponent.Count
                });
            }
        }
        public void UpdElement(GoodBinding model)
        {
            Good element = source.Products.FirstOrDefault(rec => rec.ProductName ==
           model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;
            int maxPCId = source.ProductComponents.Count > 0 ?
           source.ProductComponents.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.ProductComponents.Select(rec =>
           rec.ComponentId).Distinct();
            var updateComponents = source.ProductComponents.Where(rec => rec.ProductId ==
           model.Id && compIds.Contains(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.ProductComponents.FirstOrDefault(rec =>
               rec.Id == updateComponent.Id).Count;
            }
            source.ProductComponents.RemoveAll(rec => rec.ProductId == model.Id &&
           !compIds.Contains(rec.ComponentId));
            // новые записи
            var groupComponents = model.ProductComponents
            .Where(rec => rec.Id == 0)
           .GroupBy(rec => rec.ComponentId)
           .Select(rec => new
           {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            foreach (var groupComponent in groupComponents)
            {
                GoodComponent elementPC = source.ProductComponents.FirstOrDefault(rec
               => rec.ProductId == model.Id && rec.ComponentId == groupComponent.ComponentId);
                if (elementPC != null)
                {
                    elementPC.Count += groupComponent.Count;
                }
                else
                {
                    source.ProductComponents.Add(new GoodComponent
                    {
                        Id = ++maxPCId,
                        ProductId = model.Id,
                        ComponentId = groupComponent.ComponentId,
                        Count = groupComponent.Count
                    });
                }
            }
        }
        public void DelElement(int id)
        {
            Good element = source.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.ProductComponents.RemoveAll(rec => rec.ProductId == id);
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}