using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Linq;

namespace Persistence
{
    class ModelCarDbRepository : DbRepository<ModelCar>
    {
        public override IQueryable<ModelCar> Items => base.Items.Include(item => item.Brand);

        public ModelCarDbRepository(EntitiesDBContext db) : base(db) { }
    }
}
