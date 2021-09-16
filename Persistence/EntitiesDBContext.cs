using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class EntitiesDBContext : DbContext
    {
        public EntitiesDBContext(DbContextOptions<EntitiesDBContext> options) : base(options){}
        public DbSet<BrandCar> BrandCars { get; set; }

        public DbSet<ModelCar> ModelCars { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
