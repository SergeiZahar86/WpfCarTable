using Interfaces;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfCarTable.Models;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class Orders2019ViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public ObservableCollection<StatisticOrders> Statistics_Orders2019 { get; set; }
            = new ObservableCollection<StatisticOrders>();

        private CollectionViewSource _ModelsViewSource;
        public ICollectionView ModelsView => _ModelsViewSource.View;


        public Orders2019ViewModel(IRepository<Order> order,
        IRepository<ModelCar> modelCarRepository,
        MainWindowViewModel mainWindowViewModel)
        {
            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
            _mainWindowViewModel = mainWindowViewModel;

            if (_mainWindowViewModel.Statistics_Orders_Main_ViewModel.Count != 0)
                Statistics_Orders2019 = _mainWindowViewModel.Statistics_Orders2019_Main_ViewModel;

            _ModelsViewSource = new CollectionViewSource
            {
                Source = Statistics_Orders2019,
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

    }
}
