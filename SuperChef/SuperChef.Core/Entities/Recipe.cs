using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperChef.Core.Entities
{
    public class Recipe : BaseEntity
    {
        #region Fields
        private ICollection<string> _ingredients;
        private ICollection<string> _directions;
        private ICollection<string> _tags;
        private ICollection<Comment> _comments;
        #endregion

        #region Properties
        public string Title { get; set; }
        public int Servings { get; set; }
        public string PreparationTime { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int Upvotes { get; set; }
        #endregion

        #region Field initialization
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

        public ICollection<string> Tags
        {
            get { return _tags ?? (_tags = new List<string>()); }
            set { _tags = value; }
        }
        #endregion

        #region Navigation properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }

        public int ChefId { get; set; }
        public virtual Chef Chef { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return _comments ?? (_comments = new List<Comment>()); }
            set { _comments = value; }
        }
        #endregion

        #region Methods
        public string CombinedTags
        {
            get { return string.Join(",", _tags); }
            set
            {
                _tags = value.Split(',').Select(s => s.Trim()).ToList();
            }
        }
        #endregion
    }

}

