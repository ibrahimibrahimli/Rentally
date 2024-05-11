using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configurations
{
    public class WeExperienceConfiguration : IEntityTypeConfiguration<WeExperience>
    {
        public void Configure(EntityTypeBuilder<WeExperience> builder)
        {
            builder.ToTable("WeExperiences");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.CompletedOrders)
                .IsRequired();

            builder.Property(x => x.Customers)
                .IsRequired();

            builder.Property(x => x.Customers)
                .IsRequired();

        }
    }
}
