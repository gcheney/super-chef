using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class CuisineConfiguration : EntityTypeConfiguration<Cuisine>
    {
        internal CuisineConfiguration()
        {
            ToTable("Cuisine");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("CuisineId")
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
                .WithRequired(r => r.Cuisine)
                .HasForeignKey(r => r.CuisineId);
        }
    }
}
