using Microsoft.EntityFrameworkCore.Update.Internal;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;

namespace ProiectV1.Services.UserServices
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        void Create(User newUser);
        List<User> GetAllUsers();
        void DeleteUser(string username);
        User FindByUsername(string username);
        User FindByEmail(string email);
        void Update(User newUser);
        Role GetRoleByUsername(string username);

    }
}
