using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public interface IoCContainer
    {
        void Configure(IServiceCollection services);

        IServiceProvider GetServiceProvider();
    }
}
