using System.Collections.Generic;

namespace SuperChef.Core.Entities
{
    public class Chef : IntBaseEntity
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string Speciality { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}