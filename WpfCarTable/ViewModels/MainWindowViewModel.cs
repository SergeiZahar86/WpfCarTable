using Interfaces;
using Persistence.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfCarTable.Infrastructure.Commands;
using WpfCarTable.Models;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;
        private bool FirstRun = true;
        public ObservableCollection<StatisticOrders> Statistics_Orders_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2016_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2017_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2018_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2019_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2020_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();

        public ObservableCollection<StatisticOrders> Statistics_Orders2021_Main_ViewModel { get; set; }
            = new ObservableCollection<StatisticOrders>();





        #region CurrentModel : ViewModel - Текущая дочерняя модель-представления
        /// <summary>Текущая дочерняя модель-представления</summary>
        private ViewModel _CurrentModel;
        /// <summary>Текущая дочерняя модель-представления</summary>
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }
        #endregion

        #region Заголовок окна
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _title = "Объёмы продаж";
        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrdersViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrdersViewCommand => _ShowOrdersViewCommand
            ??= new LambdaCommand(OnShowOrdersViewCommandExecuted, CanShowOrdersViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrdersViewCommandExecute(object p) => true;
        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrdersViewCommandExecuted(object p)
        {
            CurrentModel = new OrdersViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2016 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2016ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2016ViewCommand => _ShowOrders2016ViewCommand
            ??= new LambdaCommand(OnShowOrders2016ViewCommandExecuted, CanShowOrders2016ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2016ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }
        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2016ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2016ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2017 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2017ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2017ViewCommand => _ShowOrders2017ViewCommand
            ??= new LambdaCommand(OnShowOrders2017ViewCommandExecuted, CanShowOrders2017ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2017ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2017ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2017ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2018 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2018ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2018ViewCommand => _ShowOrders2018ViewCommand
            ??= new LambdaCommand(OnShowOrders2018ViewCommandExecuted, CanShowOrders2018ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2018ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2018ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2018ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2019 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2019ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2019ViewCommand => _ShowOrders2019ViewCommand
            ??= new LambdaCommand(OnShowOrders2019ViewCommandExecuted, CanShowOrders2019ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2019ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2019ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2019ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2020 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2020ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2020ViewCommand => _ShowOrders2020ViewCommand
            ??= new LambdaCommand(OnShowOrders2020ViewCommandExecuted, CanShowOrders2020ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2020ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2020ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2020ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion

        #region Command ShowOrdersViewCommand - Отобразить представление заказов за 2021 /////////////////////////////////////////////
        /// <summary>Отобразить представление заказов</summary>
        private ICommand _ShowOrders2021ViewCommand;
        /// <summary>Отобразить представление заказов</summary>
        public ICommand ShowOrders2021ViewCommand => _ShowOrders2021ViewCommand
            ??= new LambdaCommand(OnShowOrders2021ViewCommandExecuted, CanShowOrders2021ViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление заказов</summary>
        private bool CanShowOrders2021ViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление заказов</summary>
        private void OnShowOrders2021ViewCommandExecuted(object p)
        {
            CurrentModel = new Orders2021ViewModel(_OrderRepository, _ModelCarRepository, this);
        }
        #endregion


        #region Command ShowChartViewCommand - Отобразить представление графика ///////////////////////////////////////////////////
        /// <summary>Отобразить представление графика</summary>
        private ICommand _ShowChartViewCommand;
        /// <summary>Отобразить представление графика</summary>
        public ICommand ShowChartViewCommand => _ShowChartViewCommand
            ??= new LambdaCommand(OnShowChartViewCommandExecuted, CanShowChartViewCommandExecute);
        /// <summary>Проверка возможности выполнения - Отобразить представление графика</summary>
        private bool CanShowChartViewCommandExecute(object p)
        {
            if (Statistics_Orders_Main_ViewModel.Count == 25)
                return true;
            else return false;
        }

        /// <summary>Логика выполнения - Отобразить представление графика</summary>
        private void OnShowChartViewCommandExecuted(object p)
        {
            CurrentModel = new СhartViewModel(_OrderRepository, _ModelCarRepository);
        }
        #endregion

        #endregion

        public MainWindowViewModel(
            IRepository<Order> order,
            IRepository<ModelCar> modelCarRepository)
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(
                OnCloseApplicationCommandExecuted,
                CanCloseApplicationCommandExecute);
            #endregion

            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
        }
    }
}
