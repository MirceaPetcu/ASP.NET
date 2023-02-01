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
        public void DeleteProductByCategoryByName(ProductCategory category, string name)
            {
            var product = productRepository.GetProductByCategoryByName(category, name);
            if (product != null)
            {
                productRepository.Delete(product);
                productRepository.Save();
            }
            else throw new("The product that you are looking for doesn't exist!");

        }
        public Product GetProductByCategoryByName(ProductCategory category, string name)
        {
            var product = productRepository.GetProductByCategoryByName(category, name);
            if (product != null)
                return product;
            else return null;

        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
            productRepository.Save();
        }

        public List<List<Product>> GroupByCategory()
        {
            var list = productRepository.GroupByCategory();
            return list;
        }


    }
}
