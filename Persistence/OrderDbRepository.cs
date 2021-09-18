using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Linq;

namespace Persistence
{
    class OrderDbRepository : DbRepository<Order>
    {
        public override IQueryable<Order> Items => base.Items.Include(item => item.Model_Car);

        public OrderDbRepository(EntitiesDBContext db) : base(db) { }
    }
}
