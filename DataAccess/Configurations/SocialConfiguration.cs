using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SocialConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.ToTable("Socials");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.FacebookUrl)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LinkedinUrl)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.TwitterUrl)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(x => x.PinterestUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
