using Microsoft.Extensions.DependencyInjection;

namespace WpfCarTable.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddScoped<MainWindowViewModel>()
        ;
    }
}
