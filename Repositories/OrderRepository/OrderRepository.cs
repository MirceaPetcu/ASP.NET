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

        public List<Order> GetWithDeliveryAdress()
        {
            
            
             return table.Join(context.DeliveryAdresses, order => order.Id, da => da.OrderId, (order, da) => new { order, da }).Select(obj => obj.order).ToList();
            
            
        }

       





    }
}
