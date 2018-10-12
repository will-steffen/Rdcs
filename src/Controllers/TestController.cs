using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rdcs.Models;
using Rdcs.Services;
using Rdcs.Services.External.SomeIntegration;
using Rdcs.Repositories;
using Rdcs.Core.Attributes;


namespace Rdcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Autowired] TodoItemService todoItemService;
        [Autowired] SomeIntegrationBusiness someIntegrationBusiness;

        [HttpGet]
        public string Get()
        {
            return someIntegrationBusiness.Name();
        }
    }
}
