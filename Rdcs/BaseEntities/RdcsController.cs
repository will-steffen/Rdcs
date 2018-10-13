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
        protected ActionResult Send(object response = null)
        {
            return Send(HttpStatusCode.OK, response);
        }

        protected ActionResult Send(HttpStatusCode code, object response)
        {
            return StatusCode((int)code, new JsonResult(response));
        }
    }
}
