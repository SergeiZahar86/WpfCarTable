using Interfaces;
using Persistence.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfCarTable.Infrastructure.Commands;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        //private Guid Id = new Guid("37fdeb00-149d-4c5a-f845-08d97a5f07d7");
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;

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
            CurrentModel = new OrdersViewModel(_OrderRepository, _ModelCarRepository);
        }
        #endregion

        #region Command ShowChartViewCommand - Отобразить представление графика ///////////////////////////////////////////////////
        /// <summary>Отобразить представление графика</summary>
        private ICommand _ShowChartViewCommand;

        /// <summary>Отобразить представление графика</summary>
        public ICommand ShowChartViewCommand => _ShowChartViewCommand
            ??= new LambdaCommand(OnShowChartViewCommandExecuted, CanShowChartViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление графика</summary>
        private bool CanShowChartViewCommandExecute(object p) => true;

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

            var orders = _OrderRepository.Items.Take(10).ToArray();
            var orders6 = _OrderRepository.Items.ToArray();
            List<Order> orders2 = _OrderRepository.GetAll();
            List<ModelCar> modelCars = _ModelCarRepository.GetAll();
        }
    }
}
