using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using ServicesFramework.CQRS;

namespace Trips.Queries.Handlers
{
    public class GetAllOffersQueryHandler : IQueryHandler<GetAllOffersQuery, GetAllOffersQueryResult>
    {
        private readonly IConfiguration configuration;

        public GetAllOffersQueryHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public GetAllOffersQueryResult Handle(GetAllOffersQuery command)
        {
            using (IDbConnection db = new SqlConnection(configuration["ConnectionStrings:TripsDomainDatabase"]))
            {
                var offers = db.Query<OfferViewModel>("Select Name, Description, NumberOfDays From Offers").ToList();
                return new GetAllOffersQueryResult()
                {
                    Count = offers.Count,
                    Orders = offers
                };
            }            
        }
    }
}
