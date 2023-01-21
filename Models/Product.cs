using ProiectV1.Models.Base;
using ProiectV1.Models.Enums;

namespace ProiectV1.Models
{
    public class Product : BaseEntity
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public ProductCategory? Category { get; set; }
        public ICollection<ProductPromotion>? ProductPromotions { get; set; }
        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }  


    }
}
