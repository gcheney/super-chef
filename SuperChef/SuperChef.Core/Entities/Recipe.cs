using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperChef.Core.Entities
{
    public class Recipe : Entity
    {
        #region Private Fields
        private ICollection<string> _ingredients;
        private ICollection<string> _directions;
        #endregion

        #region Properties
        public string Name { get; set; }
        public int Servings { get; set; }
        public string PreparationTime { get; set; }
        public string Description { get; set; }
        public int Upvotes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        #endregion

        #region Field Initialization
        public ICollection<string> Ingredients
        {
            get { return _ingredients ?? (_ingredients = new List<string>()); }
            set { _ingredients = value; }
        }

        public ICollection<string> Directions
        {
            get { return _directions ?? (_directions = new List<string>()); }
            set { _directions = value; }
        }
        #endregion

        #region Navigation properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }

        public int ChefId { get; set; }
        public virtual Chef Chef { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        #endregion
    }

}

