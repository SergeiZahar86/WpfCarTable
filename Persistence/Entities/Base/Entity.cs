using System;

namespace Persistence.Entities.Base
{
    /// <summary>
    /// Абстрактный класс сущности
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
