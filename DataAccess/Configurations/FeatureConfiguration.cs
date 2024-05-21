using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.IconName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Title);

            builder.HasIndex(x => new { x.Title, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Title_Name");
        }
    }
}
