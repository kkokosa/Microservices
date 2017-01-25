using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public interface IIoCContainer : IDisposable
    {
        void Configure(IServiceCollection services, IEnumerable<IIoCModule> modules);

        IServiceProvider GetServiceProvider();
    }
}
