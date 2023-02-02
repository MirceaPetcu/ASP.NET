using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectContext context) : base(context)
        {
        }

        public int NoOrdersByUserId(string username)
        {
            var noOrders = table.Where(u => u.UserName == username).Select(u => u.Orders);
            return noOrders.Count();
        }

        public User FindByUserName(string username)
        {
            return table.FirstOrDefault(x => x.UserName == username);
        }

        public User FindByEmail(string email)
        {
            return table.FirstOrDefault(x => x.Email == email);
        }

        public Role GetRoleByUsername(string username)
        {
            var role =  table.Where(u => u.UserName == username).Select(u => u.Role).First();
            
            return role;
        }

        public User? GetUserWithOrders(string username)
        {
            var user =   table.Where(u => u.UserName == username).Join(context.Orders, user => user.Id, orders => orders.UserId, (user, orders) => new { user, orders }).Select(obj => obj.user).First();
            if (user == null)
                return null;
            else return user;
        }




    }
}
