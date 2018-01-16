using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infrastructure.IoC;

namespace TicketService
{
    public class Startup
    {
        private IIoCContainer container;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        //  The ConfigureServices method typically returns void, but if its signature is changed to return IServiceProvider, a different container can be configured and returned.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            this.container = new Infrastructure.IoC.DryIoc.DryIocContainer();
            this.container.Configure( 
                new IIoCModule[] {
                    new TicketService.Commands.Module(),
                    new TicketService.Queries.Module()
                },
                services);
            return this.container.GetServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime lifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            lifetime.ApplicationStopped.Register(() => this.container.Dispose());
        }
    }
}
