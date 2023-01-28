using System.ComponentModel.DataAnnotations;

namespace ProiectV1.Models.DTOs
{
    public class UserRequestDTO
    {
        //ce trimiti la server
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
