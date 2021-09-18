using Interfaces;
using Persistence.Entities;
using WpfCarTable.ViewModels.Base;

namespace WpfCarTable.ViewModels
{
    public class СhartViewModel : ViewModel
    {
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<ModelCar> _ModelCarRepository;

        public СhartViewModel(IRepository<Order> order,
            IRepository<ModelCar> modelCarRepository)
        {
            _OrderRepository = order;
            _ModelCarRepository = modelCarRepository;
        }
    }
}
