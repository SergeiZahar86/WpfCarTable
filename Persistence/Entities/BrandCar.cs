using Persistence.Entities.Base;
using System.Collections.Generic;

namespace Persistence.Entities
{
    /// <summary>
    /// Таблица марок автомобилей
    /// </summary>
    public class BrandCar : NamedEntity
    {
        public virtual ICollection<ModelCar> ModelsCar { get; set; }
    }
}
