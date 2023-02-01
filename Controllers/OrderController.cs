using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Services.OrderServices;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        //ok
        [HttpGet("get-all-orders")]
        public IActionResult GetOrders()
        {
            var listOrders = orderService.GetAllOrders();
            if(!listOrders.Any())
                return NotFound("There is no orders!");
            return Ok(listOrders);
        }
        //nu
        [HttpGet("get-orders-with-products")]
        public IActionResult GetOrdersWithProducts()
        {
            var listOrders = orderService.GetOrdersWithProducts();
            if (!listOrders.Any())
                return NotFound("There is no orders!");
            return Ok(listOrders);
        }

        //ok
        [HttpPost("add-order")]
         public IActionResult AddOrder()
        {
            var order = new Order();
            orderService.AddOrder(order);
            return Ok();
        }
        //nu
        [HttpPut("update-order")]
        public IActionResult UpdateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {
                Products = orderDTO.Products
            };
            orderService.UpdateOrder(order);
            return Ok();
            
        }

        //ok
        [HttpDelete("delete-order")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = orderService.GetOrderById(id);
            if (order != null)
            {
                orderService.DeleteOrder(order);
                return Ok();
            }
            else
                return NotFound("there is no order with this id");
        }
    }
}
