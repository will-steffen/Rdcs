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
        public ActionResult Get()
        {
            return Send(itemDataAccess.List());
        }

        [HttpPost]
        public ActionResult Post([FromBody] string name)
        {
            Item item = itemService.Create(name);
            itemDataAccess.Save(item);
            return Send("OK");
        }
    }
}
