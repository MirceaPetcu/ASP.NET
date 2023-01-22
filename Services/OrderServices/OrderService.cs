using ProiectV1.Models;
using ProiectV1.Repositories.OrderRepository;

namespace ProiectBackendPetcuMircea.DAL.Services.OrderServices
{
    public class OrderService
    {
        public IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public List<Order> GetDataMappedByUserId(Guid userId)
        {
            return orderRepository.FindByUserId(userId);
        }
        void AddOrder(Order order)
        {
            orderRepository.Create(order);
            orderRepository.Save();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepository.GetAll();
        }

    }
}
