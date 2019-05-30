using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoRepairShopDAL.Interface;
using AutoRepairShopDAL.Binding;

namespace AutoRepairShopRestApi.Controllers
{
    public class ImplementerController : ApiController
    {
        private readonly IImplementer _service;
        public ImplementerController(IImplementer service)
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
        public void AddElement(ImplementerBinding model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(ImplementerBinding model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(ImplementerBinding model)
        {
            _service.DelElement(model.Id);
        }

    }
}
