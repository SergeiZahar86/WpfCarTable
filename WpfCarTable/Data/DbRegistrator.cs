using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;

namespace WpfCarTable.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration Configuration) => services
            .AddDbContext<EntitiesDBContext>(opt =>
        {
            var type = Configuration["Type"];
            switch (type)
            {
               case null: throw new InvalidOperationException("Не определён тип БД");
               default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");

               case "MSSQL":
                   opt.UseSqlServer(Configuration.GetConnectionString(type));
                   break;
                   //case "SQLite":
                   //    opt.UseSqlite(Configuration.GetConnectionString(type));
                   //    break;
                   //case "InMemory":
                   //    opt.UseInMemoryDatabase("Bookinist.db");
                   //    break;
            }
        })
            .AddTransient<DbInitializer>()
            .AddRepositoriesInDB()
            ;

    }
}
