using ServicesFramework.DDD;
using System;

namespace Trips.Domain
{
    public class Trip : Aggregate
    {
        private TripId tripId;
        private PlaceId placeId;
    }
}
