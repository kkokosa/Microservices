using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trips.Domain;

namespace Trips.Infrastructure
{
    class OfferEntityTypeConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey("_technicalId");
        }
    }
}
