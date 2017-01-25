using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public interface IIoCModule
    {
        void RegisterInContainer(IIoCContainer container);
    }
}
