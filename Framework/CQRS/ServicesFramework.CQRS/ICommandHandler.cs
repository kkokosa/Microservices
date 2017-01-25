using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesFramework.CQRS
{
    public interface ICommandHandler<T, R>
        where T : ICommand
        where R : ICommandResult
    {
        R Handle(T command);
    }
}
