using Microsoft.EntityFrameworkCore;
using ProiectV1.Models.Base;
using ProiectV1.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProiectV1.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        //unique si maxim de 30
        public string UserName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string HashPassword { get; set; }

        [DefaultValue(Role.User)]
        public Role Role { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
