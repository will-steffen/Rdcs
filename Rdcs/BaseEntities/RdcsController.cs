using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Rdcs.BaseEntities
{    
    [ApiController]
    public class RdcsController : ControllerBase
    {
        protected JsonResult Json(object response)
        {
            return new JsonResult(response);
        }

        protected ActionResult Send(object response)
        {
            return Send(HttpStatusCode.OK, response);
        }

        protected ActionResult Send(HttpStatusCode code, object response)
        {
            return StatusCode((int)code, response);
        }
    }
}
