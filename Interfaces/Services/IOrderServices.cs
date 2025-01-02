using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IOrderServices
    {
        Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<ServiceResponse<Order>> UpdateOrderAsync(UpdateOrderDto updateOrderDto);
    }
}
