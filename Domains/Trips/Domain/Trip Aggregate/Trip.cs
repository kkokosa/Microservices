using ServicesFramework.DDD;
using System;

namespace Trips.Domain
{
    public class Trip 
        : Entity<Trip, Trip.DomainId>, 
          IAggregateRoot
    {
        private PlaceId placeId;
        public override Trip.DomainId Id { get; protected set; }

        public class DomainId 
        {
        }
    }
}
