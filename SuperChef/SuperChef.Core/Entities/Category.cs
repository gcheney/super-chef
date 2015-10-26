using System.Collections.Generic;

namespace SuperChef.Core.Entities
{
    public class Category
    {
        private ICollection<Recipe> _recipes;

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return _recipes ?? (_recipes = new List<Recipe>()); }
            set { _recipes = value; }
        }
    }
}