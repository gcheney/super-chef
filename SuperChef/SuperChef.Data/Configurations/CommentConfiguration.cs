using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        internal CommentConfiguration()
        {
            ToTable("Comment");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("CommentId")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.DatePosted).IsRequired();

            HasRequired(c => c.Chef)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ChefId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeId)
                .WillCascadeOnDelete(true); 
        }
    }
}
