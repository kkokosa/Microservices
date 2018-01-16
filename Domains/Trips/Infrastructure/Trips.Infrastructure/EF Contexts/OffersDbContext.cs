using Microsoft.EntityFrameworkCore;
using ServicesFramework.DDD;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Trips.Domain;

namespace Trips.Infrastructure
{
    public class OffersDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DotNetTraining\\SQLEXPRESS;Database=TravelAgency.TripsDomainDatabase;Trusted_Connection=True;",
                                    sqlServerOptionsAction: sqlOptions =>
                                    {
                                        sqlOptions.MigrationsAssembly(typeof(OffersDbContext).GetTypeInfo().Assembly.GetName().Name);
                                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                    });
        }
    }
}
