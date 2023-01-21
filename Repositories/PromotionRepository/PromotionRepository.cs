using Microsoft.EntityFrameworkCore;
using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.PromotionRepository
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(ProiectContext context) : base(context)
        {
        }
        public  List<Promotion> GetProductsByPromotionId(Guid id)
        {
            return table.Include(p => p.ProductPromotions).ThenInclude(p => p.Product).ToList();

        }
        public List<List<Promotion>> GroupByStartDate()
        {
            var groupedByStartDate = from P in table
                          group P by P.StartDate;

            var promotionList = new List<List<Promotion>>();

            foreach( var periods in groupedByStartDate )
            {
                var tempList = new List<Promotion>();
                tempList.AddRange(periods);
                promotionList.Add(tempList);
            }
            return promotionList;

        }
    }
}
