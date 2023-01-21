namespace ProiectV1.Models
{
    public class ProductPromotion
    {
        public Promotion? Promotion { get; set; }
        public Product? Product { get; set; }
        public Guid PromotionId { get; set; }
        public Guid ProductId { get; set; }
    }
}
