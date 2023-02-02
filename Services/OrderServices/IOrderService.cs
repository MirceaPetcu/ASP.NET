using ProiectV1.Models;
using ProiectV1.Repositories.OrderRepository;

namespace ProiectV1.Services.OrderServices
{
    public interface IOrderService
    {
        List<Order> GetDataMappedByUserId(Guid userId);
        void AddOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        List<Order> GetOrdersWithProducts();
        void UpdateOrder(Order order);
        Order GetOrderById(Guid id);
        void DeleteOrder(Order order);
        Order? GetWithDeliveryAdressByOrderId(Guid id);


    }
}
