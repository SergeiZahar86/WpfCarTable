using Microsoft.Extensions.DependencyInjection;
using WpfCarTable.ViewModels;

namespace WpfCarTable.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()

           //.AddTransient<ISalesService, SalesService>()
           //.AddTransient<IUserDialog, UserDialogService>();
           ;
    }
}
