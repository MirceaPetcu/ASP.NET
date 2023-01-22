using ProiectV1.Data;
using ProiectV1.Models;

namespace ProiectV1.Helpers.Seeders
{
    public class ProductSeeder
    {
        public readonly ProiectContext proiectContext;

        public ProductSeeder(ProiectContext proiectContext)
        {
            this.proiectContext = proiectContext;
        }
        public void SeedInitialProducts()
        {
            if (!proiectContext.Products.Any())
            {
                var product1 = new Product
                {
                    Price = 2000,
                    Name = "Smartphone Samsung A5",
                    Category = Models.Enums.ProductCategory.Technology


                };
                var product2 = new Product
                {
                    Price = 10000.5,
                    Name = "Sofa",
                    Category = Models.Enums.ProductCategory.Home


                };
                proiectContext.Add(product1);
                proiectContext.Add(product2);
            }
        }
    }
}
