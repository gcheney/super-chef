using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperChef.Core.Entities
{
    public class Recipe : IntBaseEntity
    {
        #region Properties
        public string Name { get; set; }
        public int Servings { get; set; }
        public string PreparationTime { get; set; }
        public string Description { get; set; }
        public int Upvotes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public string Image { get; set; }

        public string CombinedIngredients
        {
            get { return string.Join(",", _ingredients); }
            set { _ingredients = value.Split(',').Select(s => s.Trim()).ToList(); }
        }

        public string CombinedDirections
        {
            get { return string.Join(",", _directions); }
            set { _directions = value.Split(',').Select(s => s.Trim()).ToList(); }
        }
        #endregion

        #region Navigation properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }

        public int CreatedById { get; set; }
        public virtual Chef CreatedBy { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        #endregion

        #region Private Fields
        private List<string> _ingredients;
        public List<string> Ingredients
        {
            get { return _ingredients ?? (_ingredients = new List<string>()); }
            set { _ingredients = value; }
        }

        private List<string> _directions;
        public List<string> Directions
        {
            get { return _directions ?? (_directions = new List<string>()); }
            set { _directions = value; }
        }
        #endregion
    }

}

