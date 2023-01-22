using ProiectV1.Models.Base;

namespace ProiectV1.Models
{
    public class Promotion : BaseEntity
    {
        public string? PromotionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public float? discount { get; set; }
        public ICollection<ProductPromotion>? ProductPromotions { get; set; }
    }
}
