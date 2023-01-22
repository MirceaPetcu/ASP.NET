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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public IActionResult AddProduct([FromBody]ProductDTO productdto)
        {
           return Ok(_productService.CreateProduct(productdto));
            
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }
    }
}
