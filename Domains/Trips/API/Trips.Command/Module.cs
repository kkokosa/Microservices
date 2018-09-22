using Infrastructure.IoC;
using ServicesFramework.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Commands;
using Trips.Commands.Handlers;
using Trips.Domain;
using Trips.Infrastructure;

namespace Trips.Commands
{
    public class Module : IIoCModule
    {
        public void RegisterInContainer(IIoCContainerRegistration containerRegistration)
        {
            containerRegistration.Register<IOfferRepository, OfferRepository>();
        }
    }
}
