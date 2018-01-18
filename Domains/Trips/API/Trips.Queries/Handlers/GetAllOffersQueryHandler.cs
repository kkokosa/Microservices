using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using ServicesFramework.CQRS;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Trips.Queries.Handlers
{
    public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, GetAllOffersQueryResult>
    {
        private readonly IConfiguration configuration;

        public GetAllOffersQueryHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<GetAllOffersQueryResult> Handle(GetAllOffersQuery command, CancellationToken token)
        {
            using (IDbConnection db = new SqlConnection(configuration["ConnectionStrings:TripsDomainDatabase"]))
            {
                var offers = db.Query<OfferViewModel>("Select Name, Description, NumberOfDays From Offers").ToList();
                return Task.FromResult(new GetAllOffersQueryResult()
                {
                    Count = offers.Count,
                    Orders = offers
                });
            }            
        }
    }
}
