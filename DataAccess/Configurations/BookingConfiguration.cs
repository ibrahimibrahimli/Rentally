using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x=>x.CarID)
                .IsRequired();

            builder.Property(x => x.PickUpLocation)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DropOffLocation)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PickUpDateTime)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DropOffDateTime)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasDefaultValue(0);

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment:1);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.UserId);
        }
    }
}
