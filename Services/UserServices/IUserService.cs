using ProiectV1.Models.DTOs;

namespace ProiectV1.Services.UserServices
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        UserRequestDTO GetById(Guid id);
        Task Create(UserRequestDTO newUser);
    }
}
