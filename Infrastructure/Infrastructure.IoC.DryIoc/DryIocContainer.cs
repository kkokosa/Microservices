using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;

namespace Infrastructure.IoC.DryIoc
{
    public class DryIocContainer : IoCContainer
    {
        private IContainer container;

        public DryIocContainer()
        {
            container = new Container();
        }

        public void Configure(IServiceCollection services)
        {
            container = container.WithDependencyInjectionAdapter(services,
                // optional: propagate exception if specified types are not resolved, and prevent fallback to default Asp resolution
                throwIfUnresolved: type => type.Name.EndsWith("Controller"));
        }

        public IServiceProvider GetServiceProvider()
        {
            return container.ConfigureServiceProvider<Dummy>();
        }
    }

    public class Dummy
    {
        public Dummy(IRegistrator r)
        {
            //r.Register<ISingletonService, SingletonService>(Reuse.Singleton);
            //r.Register<ITransientService, TransientService>(Reuse.Transient);
            //r.Register<IScopedService, ScopedService>(Reuse.InCurrentScope);

            //var assemblies = new[] { typeof(ExportedService).GetAssembly() };
            //r.RegisterExports(assemblies);
        }
    }
}
