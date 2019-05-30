using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using AutoRepairShopRestApi.Services;
using AutoRepairShopDAL.View;

namespace AutoRepairShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMain _service;
        private readonly IImplementer _serviceImplementer;
        public MainController(IMain service, IImplementer serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void CreateOrder(SOrderBinding model)
        {
            _service.CreateOrder(model);
        }
        
        [HttpPost]
        public void PayOrder(SOrderBinding model)
        {
            _service.PayOrder(model);
        }
        [HttpPost]
        public void PutComponentOnStock(SStockComponentBinding model)
        {
            _service.PutComponentOnStock(model);
        }
        [HttpPost]
        public void StartWork()
        {
            List<SOrderView> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerView impl = _serviceImplementer.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.Id);
            }
        }
    }
}
