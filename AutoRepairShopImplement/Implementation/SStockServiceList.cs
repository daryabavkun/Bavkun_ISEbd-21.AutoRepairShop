using System;
using AutoRepairShop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.View;
using AutoRepairShopDAL.Interface;

namespace AutoRepairShopImplement.Implementation
{
    public class SStockServiceList : ISStock
    {
        private DataListSingleton source;
        public SStockServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SStockView> GetList()
        {
            List<SStockView> result = source.Stocks
            .Select(rec => new SStockView
            {
                Id = rec.Id,
                StockName = rec.StockName,
                StockComponents = source.StockComponents
                .Where(recPC => recPC.StockId == rec.Id)
                .Select(recPC => new SStockComponentView
                {
                   Id = recPC.Id,
                   StockId = recPC.StockId,
                   ComponentId = recPC.ComponentId,
                   ComponentName = source.Components
                   .FirstOrDefault(recC => recC.Id == 
                   recPC.ComponentId)?.ComponentName,
                   Count = recPC.Count
                })
                   .ToList()
            })
            .ToList();
            return result;
        }
        public SStockView GetElement(int id)
        {
            SStock element = source.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SStockView
                {
                    Id = element.Id,
                    StockName = element.StockName,
                    StockComponents = source.StockComponents
                .Where(recPC => recPC.StockId == element.Id)
               .Select(recPC => new SStockComponentView
               {
                   Id = recPC.Id,
                   StockId = recPC.StockId,
                   ComponentId = recPC.ComponentId,
                   ComponentName = source.Components
                .FirstOrDefault(recC => recC.Id ==
               recPC.ComponentId)?.ComponentName,
                   Count = recPC.Count
               })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SStockBinding model)
        {
            SStock element = source.Stocks.FirstOrDefault(rec => rec.StockName ==
            model.StockName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Stocks.Count > 0 ? source.Stocks.Max(rec => rec.Id) : 0;
            source.Stocks.Add(new SStock
            {
                Id = maxId + 1,
                StockName = model.StockName
            });
        }
        public void UpdElement(SStockBinding model)
        {
            SStock element = source.Stocks.FirstOrDefault(rec =>
            rec.StockName == model.StockName && rec.Id !=
           model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Stocks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StockName = model.StockName;
        }
        public void DelElement(int id)
        {
            SStock element = source.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StockComponents.RemoveAll(rec => rec.StockId == id);
                source.Stocks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
