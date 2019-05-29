using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.Binding;
using System.Web.Http;

namespace AutoRepairShopRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReport _service;
        public ReportController(IReport service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStocksLoad()
        {
            var list = _service.GetStocksLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetClientOrders(ReportBinding model)
        {
            var list = _service.GetClientOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveProductPrice(ReportBinding model)
        {
            _service.SaveProductPrice(model);
        }
        [HttpPost]
        public void SaveStocksLoad(ReportBinding model)
        {
            _service.SaveStocksLoad(model);
        }
        [HttpPost]
        public void SaveClientOrders(ReportBinding model)
        {
            _service.SaveClientOrders(model);
        }
    }
}
