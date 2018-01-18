using Infrastructure.IoC;
using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Queries;
using Trips.Queries.Handlers;

namespace Trips.Queries
{
    public class Module : IIoCModule
    {
        public void RegisterInContainer(IIoCContainerRegistration containerRegistration)
        {
            //containerRegistration.Register<IQueryHandler<GetAllOffersQuery, GetAllOffersQueryResult>, GetAllOffersQueryHandler>();
        }
    }
}
