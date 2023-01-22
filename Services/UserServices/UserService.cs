﻿using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Models.DTOs;
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
        UserResponseDTO Authenticate(UserRequestDTO model)
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
        public Task Create(UserRequestDTO newUser)
        {
            throw new NotImplementedException;
        }
        public UserRequestDTO GetById(Guid id)
        {
            throw new NotImplementedException;
        }


    }
}
