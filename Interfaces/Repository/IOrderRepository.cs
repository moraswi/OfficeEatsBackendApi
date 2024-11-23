using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);

        Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId);

        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<Order> UpdateOrderAsync(Order order);

    }
}
