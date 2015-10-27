using System;

namespace SuperChef.Core.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        public int ChefId { get; set; }
        public Chef Chef { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}