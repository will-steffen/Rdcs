﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rdcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> values = new List<string>();
        // GET api/values
        [HttpGet("all")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            AssertPosition(id);
            return values[id];
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            values.Add(value);
            return "OK";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            AssertPosition(id);
            values[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AssertPosition(id);
            values[id] = null;
        }

        private void AssertPosition(int id) {
            if(id < 0 || id > values.Count - 1) {
                throw new Exception("Posição inválida");
            }
        }
    }
}
