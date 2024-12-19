using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

        Task<Order> UpdateOrderAsync(Order order);

    }
}
