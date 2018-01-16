using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using ServicesFramework.CQRS;

namespace Trips.Queries.Handlers
{
    public class GetAllOffersQueryHandler : IQueryHandler<GetAllOffersQuery, GetAllOffersQueryResult>
    {
        public GetAllOffersQueryResult Handle(GetAllOffersQuery command)
        {
            using (IDbConnection db = new SqlConnection("Server=DotNetTraining\\SQLEXPRESS;Database=TravelAgency.TripsDomainDatabase;Trusted_Connection=True;"))
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
