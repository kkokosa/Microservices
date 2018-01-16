using Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips.Queries;

namespace Trips.Queries
{
    public class Module : IIoCModule
    {
        public void RegisterInContainer(IIoCContainerRegistration containerRegistration)
        {
            containerRegistration.Register<IGetAllOffersQuery, GetAllOffersQuery>();
        }
    }
}
