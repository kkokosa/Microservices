﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Trips.Infrastructure;

namespace Trips.Infrastructure.Migrations
{
    [DbContext(typeof(OffersDbContext))]
    partial class OffersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trips.Domain.Offer", b =>
                {
                    b.Property<int>("_technicalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfDays");

                    b.HasKey("_technicalId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Trips.Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("FilePath");

                    b.Property<int?>("Offer_technicalId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("Offer_technicalId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Trips.Domain.Photo", b =>
                {
                    b.HasOne("Trips.Domain.Offer")
                        .WithMany("Photos")
                        .HasForeignKey("Offer_technicalId");
                });
#pragma warning restore 612, 618
        }
    }
}
