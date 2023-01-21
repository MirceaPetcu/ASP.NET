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

        public IQueryable<Product> GetByCategory(ProductCategory category)
        {
            var products = from p in table
                           where p.Category == category
                           orderby p.Price
                           select p;
            try
            {
                if (products.Count() < 0)
                    throw new NoProductsFoundException("No products found for this category.");
                return products;
            }
            catch (NoProductsFoundException ex)
            {
                return products;
            }
            
        }

    }
}
