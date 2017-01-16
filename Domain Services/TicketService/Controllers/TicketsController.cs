using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        // GET api/tickets
        [HttpGet]
        public async Task<IEnumerable<int>> Get()
        {
            var tfBlock = new TransformBlock<string, int>(x => x.Length);
            tfBlock.Post("Test");
            var result = await tfBlock.ReceiveAsync();
            return new int[] { result };
        }

        // GET api/tickets/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tickets
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
