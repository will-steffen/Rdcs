using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel.Entities;
using MyAPI.Services.Entities;
using Rdcs.Attributes;

namespace MyAPI.Api.Controllers
{
    public class ItemController : BaseController
    {
        [Autowired]
        private ItemService itemService;

        [Autowired]
        private ItemDataAccess itemDataAccess;

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(itemDataAccess.List());
        }

        [HttpPost]
        public string Post([FromBody] string name)
        {
            Item item = itemService.Create(name);
            itemDataAccess.Save(item);
            return "OK";
        }
    }
}
