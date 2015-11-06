using System.Collections.Generic;

namespace SuperChef.Core.Entities
{
    public class Category : IntBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}