using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetOrders()
        {
            var listOrders = orderService.GetAllOrders();
            if(!listOrders.Any())
                return NotFound("There is no orders!");
            return Ok(listOrders);
        }

    }
}
