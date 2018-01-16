using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesFramework.CQRS;
using Trips.Commands;

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    public class OffersController : Controller
    {
        // GET api/offers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/offers/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/offers
        [HttpPost]
        public string Post(
            [FromBody]CreateOfferCommand createOfferCommand,
            [FromServices] ICommandHandler<CreateOfferCommand, CreateOfferCommandResult> handler)
        {
            var result = handler.Handle(createOfferCommand);
            return result.Message;
        }

        // PUT api/offers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value,
            [FromServices] ICommandHandler<CreateOfferCommand, CreateOfferCommandResult> handler)
        {
            throw new NotImplementedException();
        }

        // DELETE api/offers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
