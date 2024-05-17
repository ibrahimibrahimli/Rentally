using Microsoft.EntityFrameworkCore;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.DefaultValues;

namespace DataAccess.Configurations
{
    public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.ToTable("CarCategories");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IconName)
                .HasMaxLength(100)
                .IsRequired();

            

            builder.HasIndex(x => new { x.Title, x.Deleted }).IsUnique().HasDatabaseName("idx_Title_Deleted");
        }
    }
}
