using AutoRepairShopDAL.Binding;
using AutoRepairShopDAL.Interface;
using System;
using System.Web.Http;
namespace AbstractShopRestApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly ISClient _service;
        public ClientController(ISClient service)
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
