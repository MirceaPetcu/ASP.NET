using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectV1.Services.UserServices
{
    public class UserService : IUserService
    {
        public IUserRepository userRepository;
        public IJwtUtils jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            this.userRepository = userRepository;
            this.jwtUtils = jwtUtils;
        }
        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = userRepository.FindByUserName(model.UserName);
            //daca  am gasit userul sau parola bagata in request nu se portriveste cu cea a hashita din baza de date
            // generam tojen si trimit user cu tot cu token-ul gasit
            if (user == null || !BCryptNet.Verify(model.Password, user.HashPassword))
            {
                return null;
            }
            var jwtToken = jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }
        public  void Create(User newUser)
        {
             userRepository.Create(newUser);
             userRepository.Save();

        }
        public User GetById(Guid id)
        {
            return userRepository.GetById(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }
        public void DeleteUser(string username)
        {
            var localUser = userRepository.FindByUserName(username);
            if (localUser != null)
            {
                userRepository.Delete(localUser);
            }
            userRepository.Save();
        }
        public User FindByUsername(string username)
        {
            return userRepository.FindByUserName(username);
        }
        public User FindByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }
        public void Update(User newUser)
        {
            userRepository.Update(newUser);
            userRepository.Save();
        }

        public Role GetRoleByUsername(string username)
        {
            return userRepository.GetRoleByUsername(username);
        }



    }
}
