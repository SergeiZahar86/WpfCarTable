using Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCarTable.Infrastructure.Commands;
using WpfCarTable.Models;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class OrdersViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;
        private readonly MainWindowViewModel _mainWindowViewModel;
        public ObservableCollection<StatisticOrders> Statistics_Orders { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public OrdersViewModel(IRepository<Order> order,
            IRepository<ModelCar> modelCarRepository,
            MainWindowViewModel mainWindowViewModel)
        {
            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
            _mainWindowViewModel = mainWindowViewModel;
            //var title = _mainWindowViewModel.Title;

            if (_mainWindowViewModel.Statistics_Orders_Main_ViewModel.Count != 0)
                Statistics_Orders = _mainWindowViewModel.Statistics_Orders_Main_ViewModel;
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

        #region количество моделей
        /// <summary>Заголовок окна</summary>
        public int CountModel
        {
            get => _countModel;
            set => Set(ref _countModel, value);
        }
        private int _countModel;
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
        }
        #endregion







        private string[] month = { "-01-", "-02-", "-03-", "-04-",
            "-05-", "-06-", "-07-", "-08-", "-09-", "-10-", "-11-", "-12-", };
        private List<decimal> summ = new();

        #region Command ComputeStatisticOrdersCommand - Получить данные по месяцам
        /// <summary>Получить данные по месяцам</summary>
        private ICommand _ComputeStatisticOrdersCommand;
        /// <summary>Получить данные по месяцам</summary>
        public ICommand ComputeStatisticOrdersCommand => _ComputeStatisticOrdersCommand
            ??= new LambdaCommandAsync(OnComputeStatisticOrdersCommandExecuted);
        /// <summary>Логика выполнения - Получить данные по месяцам</summary>
        private async Task OnComputeStatisticOrdersCommandExecuted(object p)
        {
            await ComputeDealsStatisticOrdersAsync();
        }
        private async Task ComputeDealsStatisticOrdersAsync()
        {
            if (_mainWindowViewModel.Statistics_Orders_Main_ViewModel.Count == 0)
            {



                var models = await _ModelCarRepository.Items.Select(x => x.Name).ToArrayAsync();
                for (int i = 0; i < models.Length; i++)
                {
                    for (int k = 0; k < month.Length; k++)
                    {
                        summ.Add(await _OrderRepository
                        .Items
                        .Where(x => x.Model_Car.Name == models[i])
                        .Where(x => EF.Functions.Like(x.Date.Date.ToString(), $"%{month[k]}%"))
                        .SumAsync(x => x.Proceeds));
                    }
                    StatisticOrders statisticOrders = new StatisticOrders
                    {
                        ModelName = models[i],
                        OrdersInJanuary = summ[0],
                        OrdersInFebruary = summ[1],
                        OrdersInMarch = summ[2],
                        OrdersInApril = summ[3],
                        OrdersInMay = summ[4],
                        OrdersInJune = summ[5],
                        OrdersInJuly = summ[6],
                        OrdersInAugust = summ[7],
                        OrdersInSeptember = summ[8],
                        OrdersInOctober = summ[9],
                        OrdersInNovember = summ[10],
                        OrdersInDecember = summ[11]
                    };
                    Statistics_Orders.Add(statisticOrders);
                    summ.Clear();
                }
                _mainWindowViewModel.Statistics_Orders_Main_ViewModel = Statistics_Orders;
            }
            //else Statistics_Orders = _mainWindowViewModel.Statistics_Orders_Main_ViewModel;
        }
        #endregion


    }
}
