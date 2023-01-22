namespace ProiectV1.Models.DTOs
{
    public class UserResponseDTO
    {
        //ce se intoarce de la server
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }

        public UserResponseDTO(User user,string token)
        {
            Token = token;
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
