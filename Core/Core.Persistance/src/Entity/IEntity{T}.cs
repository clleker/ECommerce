﻿
namespace Core.Persistance
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
