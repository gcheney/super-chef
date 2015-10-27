using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class AvatarImageConfiguration : EntityTypeConfiguration<AvatarImage>
    {
        internal AvatarImageConfiguration()
        {
            HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasColumnName("AvatarImageId")
                .HasColumnType("int")
                .IsRequired();

            Property(a => a.ImagePath)
                .HasColumnName("ImagePath")
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

            HasRequired(a => a.Chef)
                .WithOptional(c => c.AvatarImage)
                .WillCascadeOnDelete(true);
        }
    }
}
