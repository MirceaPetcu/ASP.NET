using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Repositories.ProductRepository;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpPost("CreateProduct")]
        IActionResult AddProduct(ProductDTO productdto)
        {
            var newProduct = new Product();
            newProduct.Price = productdto.price;
            newProduct.Name = productdto.name;
            productRepository.Create(newProduct);
            productRepository.Save();
            return Ok(newProduct);
        }
    }
}
