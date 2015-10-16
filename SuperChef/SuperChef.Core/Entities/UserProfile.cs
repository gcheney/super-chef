using System;
using System.ComponentModel.DataAnnotations;

namespace SuperChef.Core.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            SignUpDate = DateTime.Now;
        }

        public int UserProfileId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime SignUpDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? LastLogin { get; set; }
        public string UserBio { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }

        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
