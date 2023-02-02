using ProiectV1.Repositories.Generic;
using ProiectV1.Models;

namespace ProiectV1.Repositories.DeliveryAdressRepository
{
    public interface IDeliveryAdressRepository : IGenericRepository<DeliveryAdress>
    {
        DeliveryAdress FindDeleteAdressByStreetByNumber(string street, int number);

    }
}
