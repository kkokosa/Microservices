using System;
using System.Collections.Generic;
using System.Text;
using ServicesFramework.CQRS;

namespace Trips.Queries.Handlers
{
    public class GetAllOffersQueryHandler : IQueryHandler<GetAllOffersQuery, GetAllOffersQueryResult>
    {
        public GetAllOffersQueryResult Handle(GetAllOffersQuery command)
        {
            return new GetAllOffersQueryResult()
            {
                Count = 1,
                Orders = new List<OfferViewModel>()
                {
                    new OfferViewModel() { Name = "Aa" }
                }
            };
        }
    }
}
