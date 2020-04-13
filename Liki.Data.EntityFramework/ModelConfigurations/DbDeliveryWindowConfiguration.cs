using Liki.Data.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liki.Data.EntityFramework.ModelConfigurations
{
    public class DbDeliveryWindowConfiguration : IEntityTypeConfiguration<DbDeliveryWindow>
    {
        public void Configure(EntityTypeBuilder<DbDeliveryWindow> builder)
        {
            builder.ToTable("DeliveryWindows");

            builder.HasIndex(x => x.AvailableByHoursBefore);
            builder.HasIndex(x => new {x.Start, x.End});

            builder.Property(x => x.Start).HasColumnType("time");
            builder.Property(x => x.End).HasColumnType("time");
            builder.Property(x => x.AvailableByHoursBefore).HasColumnType("time");
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}