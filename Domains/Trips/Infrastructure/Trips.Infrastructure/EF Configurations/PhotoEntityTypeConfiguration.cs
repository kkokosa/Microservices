using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trips.Domain;

namespace Trips.Infrastructure
{
    class PhotoEntityTypeConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey("_technicalId");
        }
    }
}
