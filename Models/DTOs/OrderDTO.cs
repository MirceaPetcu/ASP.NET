using ProiectV1.Models.Enums;

namespace ProiectV1.Models.DTOs
{
    public class OrderDTO
    {
        public ICollection<Tuple<string,ProductCategory>> Products { get; set; }
    }
}
