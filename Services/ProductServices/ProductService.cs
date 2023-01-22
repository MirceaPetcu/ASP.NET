using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Repositories.ProductRepository;

namespace ProiectV1.Services.ProductServices
{
    public class ProductService : IProductService
    {
        public IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product CreateProduct(ProductDTO product)
        {
            var newProduct = new Product();
            newProduct.Price = product.price;
            newProduct.Name = product.name;
            productRepository.Create(newProduct);
            productRepository.Save();
            return newProduct;
        }
        public List<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        
    }
}
