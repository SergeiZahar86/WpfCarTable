using Persistence.Entities.Base;
using System.Collections.Generic;

namespace Persistence.Entities
{
    /// <summary>
    /// Таблица моделей автомобилей
    /// </summary>
    public class ModelCar : NamedEntity
    {
        public virtual BrandCar Brand { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
