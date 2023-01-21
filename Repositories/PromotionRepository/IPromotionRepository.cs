using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.PromotionRepository
{
    public interface IPromotionRepository : IGenericRepository<Promotion>
    {
        List<Promotion> GetProductsByPromotionId(Guid id);
        List<List<Promotion>> GroupByStartDate();
    }


}
