using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesFramework.CQRS;
using Trips.Commands;
using Trips.Queries;
using MediatR;

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    public class OffersController : Controller
    {
        private readonly IMediator mediator;

        public OffersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/offers
        [HttpGet]
        public GetAllOffersQueryResult Get()
        {
            var result = mediator.Send(new GetAllOffersQuery());
            return result.Result;
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
            [FromBody]CreateOfferCommand createOfferCommand)
        {
            var result = mediator.Send(createOfferCommand);
            return result.Result.Message;
        }

        // PUT api/offers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
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
