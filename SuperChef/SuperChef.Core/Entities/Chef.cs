using System.Collections.Generic;

namespace SuperChef.Core.Entities
{
    public class Chef : BaseEntity
    {
        #region Fields
        private ICollection<Comment> _comments;
        private ICollection<Recipe> _recipes;
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Comment> Comments
        {
            get { return _comments ?? (_comments = new List<Comment>()); }
            set { _comments = value; }
        }

        public virtual ICollection<Recipe> Recipes
        {
            get { return _recipes ?? (_recipes = new List<Recipe>()); }
            set { _recipes = value; }
        }
        #endregion
    }
}