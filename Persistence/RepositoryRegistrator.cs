using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services;
    //.AddTransient<IRepository<Book>, BooksRepository>()
    //.AddTransient<IRepository<Category>, DbRepository<Category>>()
    //.AddTransient<IRepository<Seller>, DbRepository<Seller>>()
    //.AddTransient<IRepository<Buyer>, DbRepository<Buyer>>()
    //.AddTransient<IRepository<Deal>, DealsRepository>();

    }
}
