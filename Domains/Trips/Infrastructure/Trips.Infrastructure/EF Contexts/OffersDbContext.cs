using Microsoft.EntityFrameworkCore;
using ServicesFramework.DDD;
using System;
using System.Collections.Generic;
using System.Text;
using Trips.Domain;

namespace Trips.Infrastructure
{
    public class OffersDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
