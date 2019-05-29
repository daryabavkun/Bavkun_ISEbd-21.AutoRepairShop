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
    public class SClientController : ApiController
    {
        private readonly ISClient _service;
        public SClientController(ISClient service)
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
        public void AddElement(SClientBinding model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(SClientBinding model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(SClientBinding model)
        {
            _service.DelElement(model.Id);
        }
    }
}
}
