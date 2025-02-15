using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);

        Task<OrderStatusHistory> AddOrderStatusAsync(OrderStatusHistory status);

        Task<IEnumerable<OrderStatusHistory>> GetOrderStatusByOrderIdAsync(int orderId);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<IEnumerable<Order>> GetDeliveryPatnerOfficePendingOrderAsync(int officeId);

        Task<IEnumerable<Order>> GetDeliveryPatnerOrderAsync(int deliveryPartnerId);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

        Task<Order> UpdateOrderAsync(Order order);

    }
}
