using ServicesFramework.DDD;
using System;

namespace Trips.Domain
{
    public class Trip 
        : Entity<Trip, string>, 
          IAggregateRoot
    {
        public override string Id { get; protected set; }
    }
}
