using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public interface IIoCContainerRegistration
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
    }
}
