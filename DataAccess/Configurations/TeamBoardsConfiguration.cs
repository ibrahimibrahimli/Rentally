using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeamBoardsConfiguration : IEntityTypeConfiguration<TeamBoard>
    {
        public void Configure(EntityTypeBuilder<TeamBoard> builder)
        {
            builder.ToTable("TeamBoards");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Surname)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.ImageUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.Position)
                .WithMany(x => x.TeamBoards)
                .HasForeignKey(x => x.PositionId);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Name_Deleted");
        } 
    }
}
