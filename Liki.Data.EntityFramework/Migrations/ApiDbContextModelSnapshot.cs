﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Liki.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    internal class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Liki.Data.Contracts.Models.DbDeliveryWindow", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<TimeSpan>("AvailableByHoursBefore")
                    .HasColumnType("time");

                b.Property<string>("Description");

                b.Property<TimeSpan>("End")
                    .HasColumnType("time");

                b.Property<bool>("IsAvailable");

                b.Property<string>("Name");

                b.Property<decimal>("Price")
                    .HasColumnType("money");

                b.Property<TimeSpan>("Start")
                    .HasColumnType("time");

                b.Property<int>("WindowType");

                b.HasKey("Id");

                b.HasIndex("AvailableByHoursBefore");

                b.HasIndex("Start", "End");

                b.ToTable("DeliveryWindows");

                b.HasData(
                    new
                    {
                        Id = 1,
                        AvailableByHoursBefore = new TimeSpan(0, 12, 0, 0, 0),
                        Description = "Доставка с 10:00 до 13:00",
                        End = new TimeSpan(0, 13, 0, 0, 0),
                        IsAvailable = true,
                        Name = "10:00 - 13:00",
                        Price = 50m,
                        Start = new TimeSpan(0, 10, 0, 0, 0),
                        WindowType = 0
                    },
                    new
                    {
                        Id = 2,
                        AvailableByHoursBefore = new TimeSpan(0, 3, 0, 0, 0),
                        Description = "Доставка с 14:00 до 17:00",
                        End = new TimeSpan(0, 17, 0, 0, 0),
                        IsAvailable = true,
                        Name = "14:00 - 17:00",
                        Price = 50m,
                        Start = new TimeSpan(0, 14, 0, 0, 0),
                        WindowType = 0
                    },
                    new
                    {
                        Id = 3,
                        AvailableByHoursBefore = new TimeSpan(0, 3, 0, 0, 0),
                        Description = "Доставка с 18:00 до 21:00",
                        End = new TimeSpan(0, 21, 0, 0, 0),
                        IsAvailable = true,
                        Name = "18:00 - 21:00",
                        Price = 50m,
                        Start = new TimeSpan(0, 18, 0, 0, 0),
                        WindowType = 0
                    },
                    new
                    {
                        Id = 4,
                        AvailableByHoursBefore = new TimeSpan(0, 1, 0, 0, 0),
                        Description = "Срочная доставка с 10:00 до 21:00",
                        End = new TimeSpan(0, 21, 0, 0, 0),
                        IsAvailable = true,
                        Name = "10:00 - 21:00 (срочная)",
                        Price = 100m,
                        Start = new TimeSpan(0, 10, 0, 0, 0),
                        WindowType = 1
                    });
            });
#pragma warning restore 612, 618
        }
    }
}