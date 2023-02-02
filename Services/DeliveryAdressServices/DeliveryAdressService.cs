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
            deliveryAdressRepository.Save();
        }
        public DeliveryAdress FindDeleteAdressByStreetByNumber(string street,int number)
        {
            return deliveryAdressRepository.FindDeleteAdressByStreetByNumber(street,number);
        }
        public void DeleteAdress(string street, int number)
        {
            var adress = deliveryAdressRepository.FindDeleteAdressByStreetByNumber(street, number);
            if (adress != null)
            {
                deliveryAdressRepository.Delete(adress);
                deliveryAdressRepository.Save();
            }
        }
        public List<DeliveryAdress> GetAdresses()
        {
            return deliveryAdressRepository.GetAll();
        }

    }
}
