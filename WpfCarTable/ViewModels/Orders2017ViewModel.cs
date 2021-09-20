using Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfCarTable.Infrastructure.Commands;
using WpfCarTable.Models;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class Orders2017ViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public ObservableCollection<StatisticOrders> Statistics_Orders2017 { get; set; }
            = new ObservableCollection<StatisticOrders>();

        private CollectionViewSource _ModelsViewSource;
        public ICollectionView ModelsView => _ModelsViewSource.View;


        public Orders2017ViewModel(IRepository<Order> order,
        IRepository<ModelCar> modelCarRepository,
        MainWindowViewModel mainWindowViewModel)
        {
            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
            _mainWindowViewModel = mainWindowViewModel;

            if (_mainWindowViewModel.Statistics_Orders2017_Main_ViewModel.Count != 0)
                Statistics_Orders2017 = _mainWindowViewModel.Statistics_Orders2017_Main_ViewModel;

            _ModelsViewSource = new CollectionViewSource
            {
                Source = Statistics_Orders2017,
                SortDescriptions =
                {
                    new SortDescription(nameof(StatisticOrders.ModelName), ListSortDirection.Ascending)
                }
            };
            _ModelsViewSource.Filter += OnModelsFilter;
        }

        /// <summary>
        /// Обработчик фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnModelsFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is StatisticOrders statisticOrders) || string.IsNullOrEmpty(ModelsFilter)) return;

            if (!statisticOrders.ModelName.Contains(ModelsFilter))
                e.Accepted = false;
        }

        #region ModelsFilter : string - Искомое слово
        private string _ModelsFilter;
        public string ModelsFilter
        {
            get => _ModelsFilter;
            set
            {
                if (Set(ref _ModelsFilter, value))
                    _ModelsViewSource.View.Refresh();
            }
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
            if (_mainWindowViewModel.Statistics_Orders2017_Main_ViewModel.Count == 0)
            {
                var models = await _ModelCarRepository.Items.Select(x => x.Name).ToArrayAsync();
                for (int i = 0; i < models.Length; i++)
                {
                    for (int k = 0; k < month.Length; k++)
                    {
                        summ.Add(await _OrderRepository
                        .Items
                        .Where(x => x.Model_Car.Name == models[i])
                        .Where(x => EF.Functions.Like(x.Date.Date.ToString(), $"2017{month[k]}%"))
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
                    Statistics_Orders2017.Add(statisticOrders);
                    summ.Clear();
                }
                _mainWindowViewModel.Statistics_Orders2017_Main_ViewModel = Statistics_Orders2017;
            }
        }
        #endregion

    }
}
