using ProiectV1.Models;
using ProiectV1.Repositories.OrderRepository;

namespace ProiectV1.Services.OrderServices
{
    public interface IOrderService
    {
        List<Order> GetDataMappedByUserId(Guid userId);
        void AddOrder(Order order);
        IEnumerable<Order> GetAllOrders();

    }
}
