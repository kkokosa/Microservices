using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using ServicesFramework.CQRS;
using TicketService.Commands;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        // GET api/tickets
        [HttpGet]
        public async Task<string> Get(
            [FromServices] ICommandHandler<BuyTicketCommand, BuyTicketCommandResult> handler)
        {
            var result = handler.Handle(new BuyTicketCommand() { Name = "World" });
            return result.Message;
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
