using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;

namespace Trips.Queries
{
    public class GetAllOffersQuery : IQuery
    {
    }

    public class GetAllOffersQueryResult : IQueryResult
    {
        public int Count { get; set; }

        public List<OfferViewModel> Orders { get; set; }
    }
}
