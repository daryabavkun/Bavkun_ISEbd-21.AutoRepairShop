using AutoRepairShop;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.View;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopServiceImplementDataBase.Implementations
{
    public class SStockServiceBD : ISStock
    {
        private AutoRepairDbContext context;
        public SStockServiceBD(AutoRepairDbContext context)
        {
            this.context = context;
        }
        public List<SStockView> GetList()
        {
            List<SStockView> result = context.Stocks.Select(rec => new SStockView
            {
                Id = rec.Id,
                StockName = rec.StockName
            })
            .ToList();
            return result;
        }
        public SStockView GetElement(int id)
        {
            SStock element = context.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SStockView
                {
                    Id = element.Id,
                    StockName = element.StockName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SStockBinding model)
        {
            SStock element = context.Stocks.FirstOrDefault(rec => rec.StockName == model.StockName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Stocks.Add(new SStock
            {
                StockName = model.StockName
            });
            context.SaveChanges();
        }
        public void UpdElement(SStockBinding model)
        {
            SStock element = context.Stocks.FirstOrDefault(rec => rec.StockName == model.StockName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Stocks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StockName = model.StockName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            SStock element = context.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Stocks.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}