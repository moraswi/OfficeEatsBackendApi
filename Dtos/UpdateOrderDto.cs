using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace OfficeEatsBackendApi.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }

        public int? DeliveryPartnerId { get; set; }

    }
}
