using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Repositories.ProductRepository;
using ProiectV1.Services.ProductServices;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("CreateProduct")]
        public IActionResult AddProduct(ProductDTO productdto)
        {
            var localProduct = new Product
            {
                Price = productdto.Price,
                Name = productdto.Name,
                Category = productdto.Category
            };
            productService.CreateProduct(localProduct);
            return Ok();
            
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            return Ok(productService.GetProducts());
        }
    }
}
