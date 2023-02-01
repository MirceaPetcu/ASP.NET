using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;

namespace ProiectV1.Services.ProductServices
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        List<Product> GetProducts();
        void CreateProductWithMapper();
        List<Product> GetProductsFromCategory(ProductCategory category);
        void DeleteProductByCategoryByName(ProductCategory category, string name);
        List<Product> GetAllProducts();
        Product GetProductByCategoryByName(ProductCategory category, string name);
        void UpdateProduct(Product product);
        List<List<Product>> GroupByCategory();

    }
}
