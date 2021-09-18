using Interfaces;
using System;

namespace Persistence.Entities.Base
{
    /// <summary>
    /// Абстрактный класс сущности
    /// </summary>
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
