using ProiectV1.Data;
using ProiectV1.Models;

namespace ProiectV1.Helpers.Seeders
{
    public class OrderSeeder
    {
        public  ProiectContext proiectContext;

        public OrderSeeder(ProiectContext proiectContext)
        {
            this.proiectContext = proiectContext;
        }
        public void SeedInitialOrders()
        {
            if(!proiectContext.Orders.Any())
            {
                var order1 = new Order();
                var order2  = new Order();
                proiectContext.Add(order1);
                proiectContext.Add(order2);
                proiectContext.SaveChanges();
            }
        }
    }
}
