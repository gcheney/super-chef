using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class RecipeImageConfiguration : EntityTypeConfiguration<RecipeImage>
    {
        internal RecipeImageConfiguration()
        {
            HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasColumnName("RecipeImageId")
                .HasColumnType("int")
                .IsRequired();

            Property(a => a.ImagePath)
                .HasColumnName("ImagePath")
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

            HasRequired(r => r.Recipe)
                .WithMany(r => r.RecipeImages)
                .HasForeignKey(r => r.RecipeId)
                .WillCascadeOnDelete(true);
        }
    }
}
