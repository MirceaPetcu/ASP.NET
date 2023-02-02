using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Services.DeliveryAdressServices;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryAdressController : ControllerBase
    {
        private readonly IDeliveryAdressService deliveryAdressService;

        public DeliveryAdressController(IDeliveryAdressService deliveryAdressService)
        {
            this.deliveryAdressService = deliveryAdressService;
        }

        [HttpPost("create-adress")]
        public IActionResult CreateAdress(AdressDTO adress)
        {
            var adress1 = new DeliveryAdress();
            adress1.City = adress.city;
            adress1.Country = adress.country;
            adress1.Street = adress.street;
            adress1.Number = adress.number;
            deliveryAdressService.CreateAdress(adress1);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAdresse()
        {
            return Ok(deliveryAdressService.GetAdresses());
        }
        [HttpDelete("delete-adress")]
        public IActionResult DeleteAdress(string street,int nr)
        {
            deliveryAdressService.DeleteAdress(street, nr);
            return Ok();
        }

    }
}
