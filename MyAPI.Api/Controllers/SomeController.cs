using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DomainModel.Authorization;
using MyAPI.Services.Entities;
using Rdcs.Attributes;
using Rdcs.Authorization;
using Rdcs.BaseEntities;
using Rdcs.Constants;

namespace MyAPI.Api.Controllers
{
    
    public class SomeController : BaseController
    {
        [Autowired]
        private SomeService someService;

       
        [HttpGet]
        [RdcsAuthorize((int)PermissionType.Any, PermissionLevel.Delete)]
        public ActionResult Get()
        {
            return Send(someService.GetSomething());
        }

        [HttpGet("2")]
        [RdcsAuthorize((int)PermissionType.Type1, PermissionLevel.Delete)]
        public ActionResult Get2()
        {
            //return Send(someService.GetSomething());
            new List<Permission>{
                new Permission((int)PermissionType.Any, PermissionLevel.Delete)
            };
            return null;
        }
    }
}
