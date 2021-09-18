using System;
using System.Threading.Tasks;
using WpfCarTable.Infrastructure.Commands.Base;

namespace WpfCarTable.Infrastructure.Commands
{
    public class LambdaCommandAsync : Command
    {
        private readonly Func<object,Task> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommandAsync(Func<object, Task> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _Execute(parameter);
        }
    }
}
