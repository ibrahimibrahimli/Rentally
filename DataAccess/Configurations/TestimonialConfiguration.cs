using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.CustomerName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CustomerSurname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.CustomerName);

            builder.HasIndex(x => new { x.CustomerName, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_CustomerName_Deleted");
        }
    }
}
