using ProiectV1.Data;
using ProiectV1.Models;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.DeliveryAdressRepository
{
    public class DeliveryAdressRepository :GenericRepository<DeliveryAdress>, IDeliveryAdressRepository
    {
        public DeliveryAdressRepository(ProiectContext context) : base(context)
        {

        }

    }
}
