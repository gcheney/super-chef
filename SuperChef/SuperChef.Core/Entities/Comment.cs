using System;

namespace SuperChef.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime TimePosted { get; set; }

        public int ChefId { get; set; }
        public Chef Chef { get; set; }
    }
}