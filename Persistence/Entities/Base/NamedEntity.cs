using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities.Base
{
    /// <summary>
    /// Абстрактный класс именованной сущности
    /// </summary>
    public class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
