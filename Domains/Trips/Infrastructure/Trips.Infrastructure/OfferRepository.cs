using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServicesFramework.DDD;
using Trips.Domain;

namespace Trips.Infrastructure
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OffersDbContext context;

        public IUnitOfWork UnitOfWork => context;

        public OfferRepository(OffersDbContext context)
        {
            this.context = context;
        }

        public Offer Add(Offer offer)
        {
            return context.Offers.Add(offer).Entity;
        }

        public async Task<bool> SaveChangesAndPublishEventsAsync()
        {
            await context.SaveChangesAndPublishEventsAsync();
            return true;
        }
    }
}
