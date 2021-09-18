using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Entities;

namespace Persistence
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Order>, OrderDbRepository>()
            .AddTransient<IRepository<ModelCar>, ModelCarDbRepository>()
            ;

    }
}
