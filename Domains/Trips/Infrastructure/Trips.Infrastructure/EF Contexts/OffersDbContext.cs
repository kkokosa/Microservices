using Microsoft.EntityFrameworkCore;
using ServicesFramework.DDD;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Trips.Domain;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;

namespace Trips.Infrastructure
{
    public class OffersDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Offer> Offers { get; set; }

        private readonly IMediator mediator;

        public OffersDbContext(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TravelAgency.TripsDomainDatabase;Trusted_Connection=True;",
                                    sqlServerOptionsAction: sqlOptions =>
                                    {
                                        sqlOptions.MigrationsAssembly(typeof(OffersDbContext).GetTypeInfo().Assembly.GetName().Name);
                                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                    });
        }

        public async Task SaveChangesAndPublishEventsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var domainEntities = ChangeTracker
                            .Entries<IEntity>()
                            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .OfType<INotification>()
                .ToList();
            
            domainEntities.ToList()
                .ForEach(entity => entity.Entity.DomainEvents.Clear());

            await base.SaveChangesAsync(cancellationToken);

            var tasks = domainEvents
                .Select(async (domainEvent) => await mediator.Publish(domainEvent));
            await Task.WhenAll(tasks);
        }
    }
}
