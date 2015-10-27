using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SuperChef.Data.Configurations
{
    internal class ChefConfiguration : EntityTypeConfiguration<Chef>
    {
        internal ChefConfiguration()
        {
            ToTable("Chef");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("ChefId")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Location)
                .HasColumnName("Location")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(c => c.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsOptional();

            Property(c => c.About)
                .HasColumnName("About")
                .HasColumnType("nvarchar")
                .HasMaxLength(1000)
                .IsOptional();

            Property(c => c.UserId)
                .HasColumnName("UserId")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            HasMany(c => c.Recipes)
                .WithRequired(r => r.Chef)
                .HasForeignKey(r => r.ChefId);

            HasMany(c => c.Comments)
                .WithRequired(c => c.Chef)
                .HasForeignKey(r => r.ChefId);
        }
    }
}
