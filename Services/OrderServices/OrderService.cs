using ProiectV1.Models;
using ProiectV1.Repositories.OrderRepository;
using ProiectV1.Services.OrderServices;

namespace ProiectBackendPetcuMircea.DAL.Services.OrderServices
{
    public class OrderService : IOrderService
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
        public void AddOrder(Order order)
        {
            orderRepository.Create(order);
            orderRepository.Save();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepository.GetAll();
        }

       

        public List<Order> GetOrdersWithProducts()
        {
            return orderRepository.GetOrdersWithProducts();
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.Update(order);
            orderRepository.Save();
        }

        public Order GetOrderById(Guid id)
        {
            var order = orderRepository.GetById(id);
            if (order == null)
                return null;
            else return order;
        }

        public void DeleteOrder(Order order)
        {
            orderRepository.Delete(order);
            orderRepository.Save();
        }
    }
}
