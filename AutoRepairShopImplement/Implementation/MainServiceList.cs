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
    public class MainServiceList : IMain
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SOrderView> GetList()
        {
            List<SOrderView> result = source.Orders
                .Select(rec => new SOrderView
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ProductId = rec.ProductId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id ==
                    rec.ClientId)?.ClientFIO,
                    ProductName = source.Products.FirstOrDefault(recP => recP.Id ==
                   rec.ProductId)?.ProductName,
                })
                .ToList();
            return result;
        }
        public void CreateOrder(SOrderBinding model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new SOrder
            {
                Id = maxId + 1,
                ClientId = model.ClientId,
                ProductId = model.ProductId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = SOrderStatus.Принят
            });
        }
        public void TakeOrderInWork(SOrderBinding model)
        {
            SOrder element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != SOrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var productComponents = source.ProductComponents.Where(rec => rec.ProductId
           == element.ProductId);
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = source.StockComponents
                .Where(rec => rec.ComponentId ==
               productComponent.ComponentId)
               .Sum(rec => rec.Count);
                if (countOnStocks < productComponent.Count * element.Count)
                {
                    var componentName = source.Components.FirstOrDefault(rec => rec.Id ==
                   productComponent.ComponentId);
                    throw new Exception("Не достаточно компонента " +
                   componentName?.ComponentName + " требуется " + (productComponent.Count * element.Count) +
                   ", в наличии " + countOnStocks);
                }
            }
            // списываем
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = productComponent.Count * element.Count;
                var stockComponents = source.StockComponents.Where(rec => rec.ComponentId
               == productComponent.ComponentId);
                foreach (var stockComponent in stockComponents)
                {
                    // компонентов на одном слкаде может не хватать
                    if (stockComponent.Count >= countOnStocks)
                    {
                        stockComponent.Count -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockComponent.Count;
                        stockComponent.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = SOrderStatus.Выполняется;
        }
        public void FinishOrder(SOrderBinding model)
        {
            SOrder element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != SOrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = SOrderStatus.Готов;
        }
        public void PayOrder(SOrderBinding model)
        {
            SOrder element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != SOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = SOrderStatus.Оплачен;
        }
        public void PutComponentOnStock(SStockComponentBinding model)
        {
            SStockComponent element = source.StockComponents.FirstOrDefault(rec =>
           rec.StockId == model.StockId && rec.ComponentId == model.ComponentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StockComponents.Count > 0 ?
               source.StockComponents.Max(rec => rec.Id) : 0;
                source.StockComponents.Add(new SStockComponent
                {
                    Id = ++maxId,
                    StockId = model.StockId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
        }
    }
}