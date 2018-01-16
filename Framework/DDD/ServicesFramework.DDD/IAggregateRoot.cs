using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesFramework.DDD
{
    public interface IAggregateRoot<T> where T : IEntity
    {
    }
}
