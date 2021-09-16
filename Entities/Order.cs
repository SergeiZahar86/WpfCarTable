using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public double Proceeds { get; set; }
        public DateTime Date { get; set; }
        public ModelCar Model_Car { get; set; }
    }
}
