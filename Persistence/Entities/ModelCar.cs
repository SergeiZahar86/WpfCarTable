using Persistence.Entities.Base;

namespace Persistence.Entities
{
    /// <summary>
    /// Таблица моделей автомобилей
    /// </summary>
    public class ModelCar : NamedEntity
    {
        public virtual BrandCar Brand { get; set; }
    }
}
