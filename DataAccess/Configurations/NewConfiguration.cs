using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Configurations
{
    public class NewConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("News");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Text)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(300)
                .IsRequired();

            builder.HasIndex(x => new { x.Title, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Title_Deleted");
        }
    }
}
