using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        internal CategoryConfiguration()
        {
            ToTable("Category");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("CategoryId")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            HasMany(c => c.Recipes)
                .WithRequired(r => r.Category)
                .HasForeignKey(r => r.CategoryId);
        }
    }
}
