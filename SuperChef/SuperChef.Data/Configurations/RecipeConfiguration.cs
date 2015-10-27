using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        internal RecipeConfiguration()
        {
            ToTable("Recipe");

            HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasColumnName("RecipeId")
                .HasColumnType("int")
                .IsRequired();

            Property(r => r.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(r => r.Upvotes)
                .HasColumnName("Upvotes")
                .HasColumnType("int")
                .IsRequired();

            Property(r => r.Servings)
                .HasColumnName("Servings")
                .HasColumnType("int")
                .IsOptional();

            Property(r => r.PreparationTime)
                .HasColumnName("PreparationTime")
                .HasColumnType("nvarchar")
                .IsOptional();

            Property(r => r.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("date")
                .IsRequired();

            Property(r => r.DateEdited)
                .HasColumnName("DateEdited")
                .HasColumnType("date")
                .IsOptional();

            Property(r => r.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsOptional();

            HasRequired(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .WillCascadeOnDelete(false);

            HasRequired(r => r.Cuisine)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CuisineId)
                .WillCascadeOnDelete(false);

            HasRequired(r => r.Chef)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.ChefId)
                .WillCascadeOnDelete(true);

            HasMany(r => r.Comments)
                .WithRequired(c => c.Recipe)
                .HasForeignKey(c => c.RecipeId);
        }
    }
}
