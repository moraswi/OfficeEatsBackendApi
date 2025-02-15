using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IOrderServices
    {
        Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto);

        Task<OrderStatusHistory> AddOrderStatusAsync(OrderStatusHistory status);

        Task<IEnumerable<OrderStatusHistory>> GetOrderStatusByOrderIdAsync(int orderId);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<IEnumerable<Order>> GetDeliveryPatnerOfficePendingOrderAsync(int officeId);

        Task<IEnumerable<Order>> GetDeliveryPatnerOrderAsync(int deliveryPartnerId);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<ServiceResponse<Order>> UpdateOrderAsync(UpdateOrderDto updateOrderDto);
    }
}
