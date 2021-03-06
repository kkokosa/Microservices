﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;

namespace Trips.API
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<Trips.Infrastructure.OffersDbContext>();
            services.AddOptions();
            services.AddMediatR(
                typeof(Trips.Commands.Module).Assembly, 
                typeof(Trips.Queries.Module).Assembly,
                typeof(Trips.Domain.Events.PhotoToOfferAdded).Assembly);

            this.container = new global::Infrastructure.IoC.DryIoc.DryIocContainer();
            this.container.Configure(
                new IIoCModule[] {
                    new Trips.Commands.Module(),
                    new Trips.Queries.Module()
                },
                services);

            return this.container.GetServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            lifetime.ApplicationStopped.Register(() => this.container.Dispose());

        }
    }
}
