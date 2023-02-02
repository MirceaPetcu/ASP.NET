using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.DeliveryAdressRepository;
using ProiectV1.Services.DeliveryAdressServices;
using ProiectV1.Services.OrderServices;
using ProiectV1.Services.ProductServices;
using ProiectV1.Services.UserServices;
using System.Collections.Generic;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private readonly IJwtUtils jwtUtils;
        private readonly IProductService productService;
        private readonly IDeliveryAdressService deliveryAdressService;

        public OrderController(IOrderService orderService, IUserService userService,IJwtUtils jwtUtils,IProductService productService,IDeliveryAdressService deliveryAdressService)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.jwtUtils = jwtUtils;
            this.productService = productService;
            this.deliveryAdressService = deliveryAdressService;
        }
        
        [HttpGet("get-all-orders")]
        public IActionResult GetOrders()
        {
            var listOrders = orderService.GetAllOrders();
            if(!listOrders.Any())
                return NotFound("There is no orders!");
            return Ok(listOrders);
        }
        
        [HttpGet("get-orders-with-products")]
        public IActionResult GetOrdersWithProducts()
        {
            var listOrders = orderService.GetOrdersWithProducts();
            if (!listOrders.Any())
                return NotFound("There is no orders!");
            return Ok(listOrders);
        }

       
        [HttpPost("add-order")]
         public IActionResult AddOrder()
        {
            var order = new Order();
            orderService.AddOrder(order);
            return Ok();
        }

        
        [HttpPut("update-order")]
        public IActionResult UpdateOrder(OrderDTO orderDTO,[FromQuery]Guid id)
        {

            var order = orderService.GetOrderById(id);
            if (order == null)
                return NotFound("there is no order with this id");
            else
            {
                var colectie = new List<Product>();
                foreach (var product in orderDTO.Products)
                {
                    colectie.Add(productService.GetProductByCategoryByName(product.Item2, product.Item1));
                }
                if (order.Products != null)
                {
                    foreach (var product in order.Products)
                    {
                        colectie.Add(product);
                    }
                }
                order.Products = colectie;
                orderService.UpdateOrder(order);
                return Ok();
            }
            
        }

        
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

        [HttpPost("user-place-an-order")]
        public IActionResult UserPlacesAnOrder(List<Tuple<string,ProductCategory>> products,[FromQuery]UserRequestDTO userRequestDTO, [FromQuery] string street, [FromQuery] int nr)
        {
            var response = userService.Authenticate(userRequestDTO);
            if (response == null)
            {
                return BadRequest("Username or password is incorect!You can not place an order!");
            }
            else
            {
                var user = userService.GetById(jwtUtils.ValidateJwtToken(response.Token));
                if(user == null)
                {
                    return BadRequest("You are no longer logged!");
                }
                var colectie = new List<Product>();
                foreach (var product in products)
                {
                    colectie.Add(productService.GetProductByCategoryByName(product.Item2, product.Item1));
                }
                var order = new Order();
                order.Products = colectie;
                order.User = user;
                order.UserId = user.Id;
                var adrees1 = deliveryAdressService.FindDeleteAdressByStreetByNumber(street, nr);
                if (adrees1 != null)
                {
                    order.DeliveryAdress = adrees1;
                    order.DeliveryAdressId = adrees1.Id;
                }
                orderService.AddOrder(order);
                var list = new List<Order>();
                list.Add(order);
                if(user.Orders != null)
                {
                    foreach(var order1 in user.Orders)
                    {
                        list.Add(order1);
                    }
                }
                user.Orders = list;
                userService.Update(user);

                return Ok();
            }
        }

        [HttpGet("get-orders-with-delvery-adress")]
        public IActionResult GetOrdersWithDeliveryAdress()
        {
           return Ok(orderService.GetWithDeliveryAdress());
        }
    }
}
