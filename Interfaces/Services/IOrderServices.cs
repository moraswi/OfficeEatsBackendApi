using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IOrderServices
    {
        Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

    }
}
