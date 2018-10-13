using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Services.Entities;
using Rdcs.Attributes;

namespace MyAPI.Api.Controllers
{
    public class SomeController : BaseController
    {
        [Autowired]
        private SomeService someService;

        [HttpGet]
        public ActionResult<string> Get()
        {
            return someService.getSomething();
        }
    }
}
