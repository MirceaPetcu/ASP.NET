using AutoMapper;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
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
        public void CreateProduct(Product product)
        { 
            productRepository.Create(product);
            productRepository.Save();
        }
        public void CreateProductWithMapper()
        {
            var productDto = new ProductDTO();
            Product product = mapper.Map<Product>(productDto);
        }
        public List<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
        List<Product> IProductService.GetProductsFromCategory(ProductCategory category)
        {
            return productRepository.GetByCategory(category);
        }

       
    }
}
