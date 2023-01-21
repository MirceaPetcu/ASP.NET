using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectContext context) : base(context)
        {
        }


        public int NoOrdersByUserId(Guid id)
        {
            var noOrders = table.Where(u => u.Id == id).Select(u => u.Orders);
            return noOrders.Count();
        }
    }
}
