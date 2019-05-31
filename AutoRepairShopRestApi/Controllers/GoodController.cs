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
    public class GoodController : ApiController
    {
        private readonly IGood _service;
        public GoodController (IGood service)
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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(GoodBinding model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(GoodBinding model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(GoodBinding model)
        {
            _service.DelElement(model.Id);
        }
    }
}
