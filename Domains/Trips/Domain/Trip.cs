using ServicesFramework.DDD;
using System;

namespace Trips.Domain
{
    public class Trip 
        : Entity<Trip, TripId>, 
          IAggregateRoot
    {
        private TripId tripId;
        private PlaceId placeId;
        public override TripId Id { get; protected set; }
    }
}
