﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PricingService.Bo.Infrastructure.Database;

namespace PricingService.Bo.Infrastructure.Database.Migrations
{
    [DbContext(typeof(PricingDbContext))]
    [Migration("20181114200542_CreatePolicyDB")]
    partial class CreatePolicyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PricingService.Bo.Domain.CoverPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeFrom");

                    b.Property<int>("AgeTo");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("TariffVersionId");

                    b.HasKey("Id");

                    b.HasIndex("TariffVersionId");

                    b.ToTable("CoverPrice");

                    b.HasData(
                        new { Id = 1, AgeFrom = 18, AgeTo = 28, Code = "COVER1", Price = 100m, TariffVersionId = 1 },
                        new { Id = 2, AgeFrom = 29, AgeTo = 45, Code = "COVER1", Price = 120m, TariffVersionId = 1 },
                        new { Id = 3, AgeFrom = 46, AgeTo = 65, Code = "COVER1", Price = 150m, TariffVersionId = 1 },
                        new { Id = 4, AgeFrom = 18, AgeTo = 45, Code = "COVER2", Price = 200m, TariffVersionId = 1 },
                        new { Id = 5, AgeFrom = 46, AgeTo = 65, Code = "COVER2", Price = 300m, TariffVersionId = 1 },
                        new { Id = 6, AgeFrom = 18, AgeTo = 65, Code = "COVER3", Price = 135m, TariffVersionId = 1 },
                        new { Id = 7, AgeFrom = 66, AgeTo = 999, Code = "COVER3", Price = 300m, TariffVersionId = 1 },
                        new { Id = 8, AgeFrom = 18, AgeTo = 28, Code = "COVER1", Price = 110m, TariffVersionId = 2 },
                        new { Id = 9, AgeFrom = 29, AgeTo = 45, Code = "COVER1", Price = 130m, TariffVersionId = 2 },
                        new { Id = 10, AgeFrom = 46, AgeTo = 65, Code = "COVER1", Price = 160m, TariffVersionId = 2 },
                        new { Id = 11, AgeFrom = 18, AgeTo = 45, Code = "COVER2", Price = 210m, TariffVersionId = 2 },
                        new { Id = 12, AgeFrom = 46, AgeTo = 65, Code = "COVER2", Price = 310m, TariffVersionId = 2 },
                        new { Id = 13, AgeFrom = 18, AgeTo = 65, Code = "COVER3", Price = 145m, TariffVersionId = 2 },
                        new { Id = 14, AgeFrom = 66, AgeTo = 999, Code = "COVER3", Price = 310m, TariffVersionId = 2 }
                    );
                });

            modelBuilder.Entity("PricingService.Bo.Domain.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Tariff");

                    b.HasData(
                        new { Id = 1, Code = "GOLDEN_HEALTH" }
                    );
                });

            modelBuilder.Entity("PricingService.Bo.Domain.TariffVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CoverFrom");

                    b.Property<DateTime>("CoverTo");

                    b.Property<int>("TariffId");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("TariffVersion");

                    b.HasData(
                        new { Id = 1, CoverFrom = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CoverTo = new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), TariffId = 1 },
                        new { Id = 2, CoverFrom = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CoverTo = new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), TariffId = 1 }
                    );
                });

            modelBuilder.Entity("PricingService.Bo.Domain.CoverPrice", b =>
                {
                    b.HasOne("PricingService.Bo.Domain.TariffVersion")
                        .WithMany("CoverPrices")
                        .HasForeignKey("TariffVersionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PricingService.Bo.Domain.TariffVersion", b =>
                {
                    b.HasOne("PricingService.Bo.Domain.Tariff")
                        .WithMany("TariffVersions")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
