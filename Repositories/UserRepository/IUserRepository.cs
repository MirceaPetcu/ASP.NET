using ProiectV1.Models;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        int NoOrdersByUserId(Guid id);
        User FindByUserName(string username);
        User FindByEmail(string email);
        Role GetRoleByUsername(string username);
    }
    

}
