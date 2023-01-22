namespace ProiectV1.Models.DTOs
{
    public class PromotionDTO
    {
        public string PromotionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float discount { get; set; }
    }
}
