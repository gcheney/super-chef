using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;


namespace SuperChef.Data.Configurations
{
    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            ToTable("UserProfiles");

            HasKey(u => u.ProfileId)
                .Property(u => u.ProfileId)
                .HasColumnName("ProfileId")
                .IsRequired();

            Property(p => p.CreationDate)
                .IsRequired();
        }
    }
}
