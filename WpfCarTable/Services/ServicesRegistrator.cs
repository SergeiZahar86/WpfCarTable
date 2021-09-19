using Microsoft.Extensions.DependencyInjection;
using WpfCarTable.ViewModels;

namespace WpfCarTable.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<OrdersViewModel>()

           //.AddTransient<ISalesService, SalesService>()
           //.AddTransient<IUserDialog, UserDialogService>();
           ;
    }
}
