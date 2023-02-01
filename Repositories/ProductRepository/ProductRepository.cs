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
            var products = table.Where(x => x.Category == category).OrderBy(x => x.Price).ToList();
            return products;
            
        }
        public Product GetProductByCategoryByName(ProductCategory category, string name)
        {
            var product = table.FirstOrDefault(x => x.Category == category && x.Name == name);
            if (product != null)
                return product;
            else return null;
        }

        public List<List<Product>> GroupByCategory()
        {
            var groupedByCategory = from P in table
                                     group P by P.Category;

            var productsList = new List<List<Product>>();

            foreach (var category in groupedByCategory)
            {
                var tempList = new List<Product>();
                tempList.AddRange(category);
                productsList.Add(tempList);
            }
            return productsList;

        }

    }
}
