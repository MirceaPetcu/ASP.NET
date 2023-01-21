using ProiectV1.Models.Base;

namespace ProiectV1.Models
{
    public class Order : BaseEntity
    {
        public ICollection<Product>? Products { get; set; }
        public DeliveryAdress? DeliveryAdress { get; set; }
        public Guid? DeliveryAdressId { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }

    }
}
