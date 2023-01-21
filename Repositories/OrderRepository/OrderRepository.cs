using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProiectContext context) : base(context)
        {

        }
        public List<Order> FindByUserId(Guid userId)
        {
            return table.Where(o => o.UserId == userId).ToList();
        }

    
        public IQueryable<Order> GetWithDeliveryAdressByOrderId(Guid id)
        {
            
            var orders = table.Join(context.Orders, deliveryAdress => deliveryAdress.Id, order => order.DeliveryAdressId, (order, deliveryAdress) => new { order, deliveryAdress }).Select(o => o.deliveryAdress).Where(o => o.Id == id);
            return orders;
        }


    }
}
