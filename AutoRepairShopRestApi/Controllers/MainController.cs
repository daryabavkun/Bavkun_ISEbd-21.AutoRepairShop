using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;

namespace AutoRepairShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMain _service;
        public MainController(IMain service)
        {
            _service = service;
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
        public void TakeOrderInWork(SOrderBinding model)
        {
            _service.TakeOrderInWork(model);
        }
        [HttpPost]
 public void FinishOrder(SOrderBinding model)
        {
            _service.FinishOrder(model);
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
    }
}
