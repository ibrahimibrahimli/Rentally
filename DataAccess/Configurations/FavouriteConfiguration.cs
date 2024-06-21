using Microsoft.EntityFrameworkCore;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.DefaultValues;

namespace DataAccess.Configurations
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.ToTable("Favourites");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.HasMany(x => x.FavouriteItems)
                .WithOne(x => x.Favourite)
                .HasForeignKey(x => x.FavouriteId);

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
