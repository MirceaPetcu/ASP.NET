using Microsoft.Extensions.Options;
using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        //functii cu join,include,where,order pentru fiecare tabela separat
        List<Order> FindByUserId(Guid userId);
        Order? GetWithDeliveryAdressByOrderId(Guid id);
        List<Order> GetOrdersWithProducts();



    }

}
