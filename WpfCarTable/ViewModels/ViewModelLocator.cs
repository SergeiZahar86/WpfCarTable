using Microsoft.Extensions.DependencyInjection;

namespace WpfCarTable.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel =>
            App.Services.GetRequiredService<MainWindowViewModel>();
    }
}