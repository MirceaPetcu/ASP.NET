using AutoMapper;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Repositories.ProductRepository;

namespace ProiectV1.Services.ProductServices
{
    public class ProductService : IProductService
    {
        public IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public Product CreateProduct(ProductDTO product)
        {
            var newProduct = new Product();
            newProduct.Price = product.Price;
            newProduct.Name = product.Name;
            productRepository.Create(newProduct);
            productRepository.Save();
            return newProduct;
        }
        public Product CreateProductWithMapper()
        {
            var productDto = new ProductDTO();
            Product product = mapper.Map<Product>(productDto);
        }
        public List<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        
    }
}
