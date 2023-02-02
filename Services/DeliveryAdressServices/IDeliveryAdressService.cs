using ProiectV1.Models;

namespace ProiectV1.Services.DeliveryAdressServices
{
    public interface IDeliveryAdressService
    {
        void CreateAdress(DeliveryAdress deliveryAdress);
        DeliveryAdress FindDeleteAdressByStreetByNumber(string street, int number);
        void DeleteAdress(string street, int number);
        List<DeliveryAdress> GetAdresses();

    }
}
