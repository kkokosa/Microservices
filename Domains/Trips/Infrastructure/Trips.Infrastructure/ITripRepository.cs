using ServicesFramework.DDD;
using System;
using Trips.Domain;

namespace Trips.Infrastructure
{
    public interface ITripRepository : IRepository<Trip>
    {

    }
}
