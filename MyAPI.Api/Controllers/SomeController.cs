using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Services.Entities;
using Rdcs.Attributes;

namespace MyAPI.Api.Controllers
{
    public class SomeController : BaseController
    {
        [Autowired]
        private SomeService someService;

        //[Authorize("Bearer")]
        [HttpGet]
        public ActionResult Get()
        {
            return Send(HttpStatusCode.NotFound, someService.GetSomething());
        }
    }
}
