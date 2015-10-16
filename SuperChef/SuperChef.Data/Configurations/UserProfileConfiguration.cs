using SuperChef.Core.Entities;
using System.Data.Entity.ModelConfiguration;


namespace SuperChef.Data.Configurations
{
    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            HasKey(u => u.UserProfileId)
                .Property(u => u.UserProfileId)
                .IsRequired();

            Property(u => u.FirstName).HasMaxLength(50);
            Property(u => u.LastName).HasMaxLength(100);
            Property(u => u.UserBio).IsMaxLength();
        }
    }
}
