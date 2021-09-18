using Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCarTable.Infrastructure.Commands;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class OrdersViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;

        public OrdersViewModel(IRepository<Order> order,
            IRepository<ModelCar> modelCarRepository)
        {
            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
        }

        #region количество заказов
        /// <summary>Заголовок окна</summary>
        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }
        private int _count;
        #endregion

        #region Command ComputeStatisticCommand - Вычислить статистические данные

        /// <summary>Вычислить статистические данные</summary>
        private ICommand _ComputeStatisticCommand;

        /// <summary>Вычислить статистические данные</summary>
        public ICommand ComputeStatisticCommand => _ComputeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecuted);

        /// <summary>Логика выполнения - Вычислить статистические данные</summary>
        private async Task OnComputeStatisticCommandExecuted(object p)
        {
            await ComputeDealsStatisticAsync();
        }

        private async Task ComputeDealsStatisticAsync()
        {
            Count = await _OrderRepository.Items.CountAsync();

            //foreach (var bestseller in await bestsellers_query.ToArrayAsync())
            //    Bestsellers.Add(bestseller);
        }

        #endregion

    }
}
