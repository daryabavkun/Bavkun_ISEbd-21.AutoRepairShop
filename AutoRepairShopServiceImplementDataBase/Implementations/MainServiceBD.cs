﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.View;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class MainServiceBD : IMain
    {
        private AutoRepairDbContext context;
        public MainServiceBD(AutoRepairDbContext context)
        {
            this.context = context;
        }
        public List<SOrderView> GetList()
        {
            List<SOrderView> result = context.Orders.Select(rec => new SOrderView
            {
                Id = rec.Id,
                ClientId = rec.ClientId,
                ProductId = rec.ProductId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                ClientFIO = rec.Client.ClientFIO,
                ProductName = rec.Product.ProductName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(SOrderBinding model)
        {
            context.Orders.Add(new SOrder
            {
                ClientId = model.ClientId,
                ProductId = model.ProductId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = SOrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(SOrderBinding model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    SOrder element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != SOrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var productComponents = context.ProductComponents.Include(rec =>
                    rec.Component).Where(rec => rec.ProductId == element.ProductId);
                    // списываем
                    foreach (var productComponent in productComponents)
                    {
                        int countOnStocks = productComponent.Count * element.Count;
                        var stockComponents = context.StockComponents.Where(rec =>
                        rec.ComponentId == productComponent.ComponentId);
                        foreach (var stockComponent in stockComponents)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockComponent.Count >= countOnStocks)
                            {
                                stockComponent.Count -= countOnStocks;
                                countOnStocks = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= stockComponent.Count;
                                stockComponent.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " + productComponent.Component.ComponentName + " требуется " + productComponent.Count + ", не хватает " + countOnStocks);
                         }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = SOrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(SOrderBinding model)
        {
            SOrder element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != SOrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = SOrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(SOrderBinding model)
        {
            SOrder element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != SOrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = SOrderStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutComponentOnStock(SStockComponentBinding model)
        {
            SStockComponent element = context.StockComponents.FirstOrDefault(rec =>
           rec.StockId == model.StockId && rec.ComponentId == model.ComponentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StockComponents.Add(new SStockComponent
                {
                    StockId = model.StockId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
