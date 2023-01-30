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
    }
}
