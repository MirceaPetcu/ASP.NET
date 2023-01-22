using ProiectV1.Models;
using ProiectV1.Models.DTOs;

namespace ProiectV1.Services.ProductServices
{
    public interface IProductService
    {
        Product CreateProduct(ProductDTO product);
        List<Product> GetProducts();
    }
}
