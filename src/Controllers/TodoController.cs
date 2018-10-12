using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rdcs.Models;
using Rdcs.Repositories;
using Rdcs.Core.Attributes;


namespace Rdcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [Autowired] TodoItemRepository todoItemRepository;    

        [HttpPost]
        public void Post([FromBody] string name)
        {
            todoItemRepository.Create(name);
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(todoItemRepository.List());
        } 

    }

}