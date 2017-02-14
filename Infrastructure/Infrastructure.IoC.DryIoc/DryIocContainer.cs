using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;

namespace Infrastructure.IoC.DryIoc
{
    public class DryIocContainer : IIoCContainer, IIoCContainerRegistration
    {
        private IContainer container;

        public DryIocContainer()
        {
            container = new Container();
        }

        public void Configure(IEnumerable<IIoCModule> modules, IServiceCollection services)
        {
            container = container.WithDependencyInjectionAdapter(services,
                // optional: propagate exception if specified types are not resolved, and prevent fallback to default Asp resolution
                throwIfUnresolved: type => type.Name.EndsWith("Controller"));
            modules.ToList().ForEach(module => module.RegisterInContainer(this));
        }

        public IServiceProvider GetServiceProvider()
        {
            return container.ConfigureServiceProvider<Dummy>();
        }
        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            this.container.Register<TService, TImplementation>();
        }
        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    container.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
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
