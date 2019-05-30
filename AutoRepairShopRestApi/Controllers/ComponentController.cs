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
    public class ComponentController : ApiController
    {
        private readonly ISComponent _service;
        public ComponentController(ISComponent service)
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
        public void AddElement(SComponentBinding model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(SComponentBinding model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(SComponentBinding model)
        {
            _service.DelElement(model.Id);
        }
    }
}
