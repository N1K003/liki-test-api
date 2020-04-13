using System;
using Liki.Data.Contracts.Models;
using Liki.Data.EntityFramework.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Liki.Data.EntityFramework
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbDeliveryWindowConfiguration());

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbDeliveryWindow>()
                .HasData(
                    new DbDeliveryWindow
                    {
                        Id = 1,
                        Name = "10:00 - 13:00",
                        Description = "Доставка с 10:00 до 13:00",
                        AvailableByHoursBefore = TimeSpan.FromHours(12),
                        WindowType = 0,
                        Start = new TimeSpan(10, 0, 0),
                        End = new TimeSpan(13, 0, 0),
                        Price = 50,
                        IsAvailable = true
                    },
                    new DbDeliveryWindow
                    {
                        Id = 2,
                        Name = "14:00 - 17:00",
                        Description = "Доставка с 14:00 до 17:00",
                        AvailableByHoursBefore = TimeSpan.FromHours(3),
                        WindowType = 0,
                        Start = new TimeSpan(14, 0, 0),
                        End = new TimeSpan(17, 0, 0),
                        Price = 50,
                        IsAvailable = true
                    },
                    new DbDeliveryWindow
                    {
                        Id = 3,
                        Name = "18:00 - 21:00",
                        Description = "Доставка с 18:00 до 21:00",
                        AvailableByHoursBefore = TimeSpan.FromHours(3),
                        WindowType = 0,
                        Start = new TimeSpan(18, 0, 0),
                        End = new TimeSpan(21, 0, 0),
                        Price = 50,
                        IsAvailable = true
                    },
                    new DbDeliveryWindow
                    {
                        Id = 4,
                        Name = "10:00 - 21:00 (срочная)",
                        Description = "Срочная доставка с 10:00 до 21:00",
                        AvailableByHoursBefore = TimeSpan.FromHours(1),
                        WindowType = 1,
                        Start = new TimeSpan(10, 0, 0),
                        End = new TimeSpan(21, 0, 0),
                        Price = 100,
                        IsAvailable = true
                    }
                );
        }
    }
}