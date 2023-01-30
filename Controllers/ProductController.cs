using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
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

        [HttpGet("get-product-by-category")]
        public IActionResult GetProductByCategory(ProductCategory category)
        {
            var list = productService.GetProductsFromCategory(category);
            var emptyList = new List<Product>();
            if (list == emptyList)
                return NotFound();
            else
                return Ok(list);
        }
    }
}
