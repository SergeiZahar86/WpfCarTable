using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ModelCar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BrandCar Brand { get; set; }
    }
}
