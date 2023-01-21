using ProiectV1.Models.Base;

namespace ProiectV1.Models
{
    public class DeliveryAdress : BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public Order? Order {get; set; }
        public Guid? OrderId { get; set; }
        }
}
