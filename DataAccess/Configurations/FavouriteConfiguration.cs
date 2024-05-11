using Microsoft.EntityFrameworkCore;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.ToTable("Favourites");

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
