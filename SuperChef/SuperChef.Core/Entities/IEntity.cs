﻿
namespace SuperChef.Core.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
