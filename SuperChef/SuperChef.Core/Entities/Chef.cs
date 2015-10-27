using System.Collections.Generic;

namespace SuperChef.Core.Entities
{
    public class Chef : Entity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string About { get; set; }

        public int AvatarImageId { get; set; }
        public virtual AvatarImage AvatarImage { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}