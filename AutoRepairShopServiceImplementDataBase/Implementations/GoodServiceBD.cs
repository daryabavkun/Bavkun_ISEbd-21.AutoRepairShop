using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.View;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class GoodServiceBD : IGood
    {
        private AutoRepairDbContext context;
        public GoodServiceBD(AutoRepairDbContext context)
        {
            this.context = context;
        }
        public List<GoodView> GetList()
        {
            List<GoodView> result = context.Products.Select(rec => new
           GoodView
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                Price = rec.Price,
                ProductComponents = context.ProductComponents
            .Where(recPC => recPC.ProductId == rec.Id)
           .Select(recPC => new GoodComponentView
           {
               Id = recPC.Id,
               ProductId = recPC.ProductId,
               ComponentId = recPC.ComponentId,
               ComponentName = recPC.Component.ComponentName,
               Count = recPC.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public GoodComponentView GetElement(int id)
        {
            Good element = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GoodView
                {
                    Id = element.Id,
                    ProductName = element.ProductName,
                    Price = element.Price,
                    ProductComponents = context.ProductComponents
                    .Where(recPC => recPC.ProductId == element.Id)
                    .Select(recPC => new GoodComponentView
                    {
                         Id = recPC.Id,
                         ProductId = recPC.ProductId,
                         ComponentId = recPC.ComponentId,
                         ComponentName = recPC.Components.ComponentName,
                         Count = recPC.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(GoodBinding model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Good element = context.Products.FirstOrDefault(rec =>
                   rec.ProductName == model.ProductName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Good
                    {
                        ProductName = model.ProductName,
                        Price = model.Price
                    };
                    context.Products.Add(element);
                    context.SaveChanges();
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
                        context.ProductComponents.Add(new GoodComponent
                        {
                            ProductId = element.Id,
                            ComponentId = groupComponent.ComponentId,
                            Count = groupComponent.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(GoodBinding model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Good element = context.Products.FirstOrDefault(rec =>
                   rec.ProductName == model.ProductName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.ProductName = model.ProductName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.ProductComponents.Select(rec =>
                   rec.ComponentId).Distinct();
                    var updateComponents = context.ProductComponents.Where(rec =>
                   rec.ProductId == model.Id && compIds.Contains(rec.ComponentId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.Count =
                       model.ProductComponents.FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
                    }
                    context.SaveChanges();
                    context.ProductComponents.RemoveRange(context.ProductComponents.Where(rec =>
                    rec.ProductId == model.Id && !compIds.Contains(rec.ComponentId)));
                    context.SaveChanges();
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
                        GoodComponent elementPC =
                       context.ProductComponents.FirstOrDefault(rec => rec.ProductId == model.Id &&
                       rec.ComponentId == groupComponent.ComponentId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.ProductComponents.Add(new GoodComponent
                            {
                                ProductId = model.Id,
                                ComponentId = groupComponent.ComponentId,
                                Count = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Good element = context.Products.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.ProductComponents.RemoveRange(context.ProductComponents.Where(rec =>
                        rec.ProductId == id));
                        context.Products.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
