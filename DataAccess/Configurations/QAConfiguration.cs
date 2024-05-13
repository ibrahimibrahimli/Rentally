using Microsoft.EntityFrameworkCore;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.DefaultValues;

namespace DataAccess.Configurations
{
    public class QAConfiguration : IEntityTypeConfiguration<QA>
    {
        public void Configure(EntityTypeBuilder<QA> builder)
        {
            builder.ToTable("QuestionsAnswers");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Question)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Answer)
                .HasMaxLength (1000)
                .IsRequired();
        }
    }
}
