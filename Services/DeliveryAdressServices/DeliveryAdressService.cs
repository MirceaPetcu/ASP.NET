using ProiectV1.Models;
using ProiectV1.Repositories.DeliveryAdressRepository;

namespace ProiectV1.Services.DeliveryAdressServices
{
    public class DeliveryAdressService : IDeliveryAdressService
    {
        public IDeliveryAdressRepository deliveryAdressRepository;

        public DeliveryAdressService(IDeliveryAdressRepository deliveryAdressRepository)
        {
            this.deliveryAdressRepository = deliveryAdressRepository;
        }

        public void CreateAdress(DeliveryAdress deliveryAdress)
        {
            deliveryAdressRepository.Create(deliveryAdress);
        }

    }
}
