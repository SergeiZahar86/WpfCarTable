using Persistence.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    /// <summary>
    /// Таблица заказов
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// Сумма покупки
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Proceeds { get; set; }
        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Модель купленной машины
        /// </summary>
        public ModelCar Model_Car { get; set; }

    }
}
