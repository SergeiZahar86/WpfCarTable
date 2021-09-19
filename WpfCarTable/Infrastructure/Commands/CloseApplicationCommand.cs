using System.Windows;
using WpfCarTable.Infrastructure.Commands.Base;

namespace WpfCarTable.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
