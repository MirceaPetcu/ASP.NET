using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.ProductRepository;
using ProiectV1.Services.ProductServices;
using System.Linq.Expressions;

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

        [HttpGet("get-products-by-category")]
        public IActionResult GetProductByCategory(ProductCategory category)
        {
            var list = productService.GetProductsFromCategory(category);
            var emptyList = new List<Product>();
            if (list == emptyList)
                return NotFound();
            else
                return Ok(list);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct(ProductDTO productDTO)
        {
            var localProduct = productService.GetProductByCategoryByName(productDTO.Category, productDTO.Name);
            if (localProduct == null)
            {
                var newProduct = new Product()
                {
                    Price = productDTO.Price,
                    Name = productDTO.Name,
                    Category = productDTO.Category
                };
                productService.CreateProduct(newProduct);
                return Ok();
            }
            else return BadRequest("This product already exists!");
        }

        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(ProductCategory category, string name)
        {
            try
            { productService.DeleteProductByCategoryByName(category, name); }
            catch (Exception ex)
            {
                return NotFound("The product does not exists.");
            }
            return Ok();
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            return Ok(productService.GetAllProducts());
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct(ProductDTO productDTO,[FromQuery]ProductCategory category, [FromQuery] string name)
        {
            var productToUpdate = productService.GetProductByCategoryByName(category, name);
            if (productToUpdate == null)
                return BadRequest("The product does not exists.");
            productToUpdate.Name = productDTO.Name;
            productToUpdate.Price = productDTO.Price;
            productToUpdate.Category = productDTO.Category;
            productService.UpdateProduct(productToUpdate);
            return Ok();
        }

        [HttpGet("get-all-grouped-by-category")]
        public IActionResult GetGroupedByCategory()
        {
            return Ok(productService.GroupByCategory());
        }
        


    }
}
