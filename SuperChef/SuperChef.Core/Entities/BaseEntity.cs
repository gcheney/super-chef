﻿
namespace SuperChef.Core.Entities
{
    public abstract class BaseEntity : IEntity<int>
    {
        public int Id { get; set; }
    }
}
