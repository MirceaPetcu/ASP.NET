using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.Generic;
using ProiectV1.Helpers.Exceptions;

namespace ProiectV1.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProiectContext context) : base(context)
        {
        }

        public List<Product> GetByCategory(ProductCategory category)
        {
            var products = table.Where(x => x.Category == category).Select(x => x).OrderBy(x => x.Price).ToList();
            return products;
            
        }

    }
}
