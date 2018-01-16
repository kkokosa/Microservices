using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesFramework.CQRS
{
    public interface IQueryHandler<T, R>
        where T : IQuery
        where R : IQueryResult
    {
        R Handle(T command);
    }
}
