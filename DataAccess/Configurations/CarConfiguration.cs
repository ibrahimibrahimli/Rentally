using Microsoft.EntityFrameworkCore;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.DefaultValues;

namespace DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Brand)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Model)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CarCategoryId)
                .IsRequired();

            builder.Property(x => x.DoorCount)
                .IsRequired();
            builder.Property(x => x.Year)
                .IsRequired();

            builder.Property(x => x.PricePerDay)
                .IsRequired()
                .HasPrecision(7,2);

            builder.HasIndex(x => new { x.Brand, x.Model, x.Year, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Brand_Deleted");

            builder.HasIndex(x => x.Brand);

            builder.HasMany(c => c.Favourites)
           .WithMany(f => f.Cars)
           .UsingEntity(x => x.ToTable("Favourites_Cars"));

            builder.HasOne(x => x.CarCategory)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CarCategoryId);
        }
    }
}
