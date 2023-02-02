using Microsoft.EntityFrameworkCore;
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



        public List<Order> GetOrdersWithProducts()
        {
            return table.Include(o => o.Products).ToList();
        }

        public Order? GetWithDeliveryAdressByOrderId(Guid id)
        {
            
            var orders = table.Where(o => o.Id == id).Join(context.Orders, deliveryAdress => deliveryAdress.Id, order => order.DeliveryAdressId, (order, deliveryAdress) => new { order, deliveryAdress }).Select(o => o.deliveryAdress);
            
            if (orders.Count() == 0)
                return null;
            else return orders.First();
        }

       





    }
}
