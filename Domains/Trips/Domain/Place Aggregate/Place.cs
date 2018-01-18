using System;
using System.Collections.Generic;
using System.Text;
using ServicesFramework.DDD;
using MediatR;
using Trips.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Trips.Domain
{
    public class Place : INotificationHandler<PhotoToOfferAdded>
    {
        public Task Handle(PhotoToOfferAdded @event, CancellationToken cancellationToken)
        {
            // do something!
            return Task.CompletedTask;
        }
    }
}
