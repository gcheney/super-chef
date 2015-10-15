using System;

namespace SuperChef.Core.Entities
{
    public class UserProfile
    {
        public int ProfileId { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }

        public virtual ApplicationUser User { get; set; }

        public UserProfile()
        {
            CreationDate = DateTime.Now;
        }

    }
}
