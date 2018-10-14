using Microsoft.AspNetCore.Mvc;
using MyAPI.Api.Dtos.Request;
using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel.Entities;
using MyAPI.Services.Entities;
using Rdcs.Attributes;
using Rdcs.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyAPI.Api.Controllers
{
    public class AuthController : BaseController
    {
        [Autowired]
        private UserService userService;

        [Autowired]
        private UserDataAccess userDataAccess;

        [HttpPost("login")]
        public object Login([FromBody] string username)        
        {
            try
            {
                return userService.Authenticate(username);
            }
            catch (Exception e)
            {
                return Send(HttpStatusCode.InternalServerError);
            }            
        }

        [HttpPost("register")]
        public object Register([FromBody] RegisterUserResquestDTO payload)
        {
            userService.Register(payload.name, payload.username);
            return Send("Ok");
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Send(userDataAccess.List());
        }
    }
}
