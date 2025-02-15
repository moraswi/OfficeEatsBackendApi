using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId)
        {
            var results = await _context.Order
                        .Where(x => x.ShopId == storeId && 
                        x.OrderStatus == "Pending" || 
                        x.OrderStatus == "Accepted"  || 
                        x.OrderStatus == "Assigned to Delivery")
                        .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var results = await _context.OrderItem.Where(x => x.OrderId == orderId).ToListAsync();
            return results;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var results = await _context.Order
                .Include(o => o.Items).
                Include(o => o.OrderStatusHistory).
                FirstOrDefaultAsync(o => o.Id == orderId);
            return results;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var results = await _context.Order
                .Include(o => o.Items)
                .Include(o => o.OrderStatusHistory)
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return results;
        }


        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetDeliveryPatnerOfficePendingOrderAsync(int officeId)
        {
            return await _context.Order
                .Include(o => o.Items)
                .Include(o => o.OrderStatusHistory)
                .Where(x => x.OfficeId == officeId &&
                            (x.OrderStatus == "Accepted"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetDeliveryPatnerOrderAsync(int deliveryPartnerId)
        {
             return await _context.Order
                .Include(o => o.Items)
                .Include(o => o.OrderStatusHistory)
                .Where(x => x.DeliveryPartnerId == deliveryPartnerId &&
                            x.OrderStatus != "Completed" && x.OrderStatus != "Accepted")
                .ToListAsync();
        }

        public async Task<OrderStatusHistory> AddOrderStatusAsync(OrderStatusHistory status)
        {
            await _context.OrderStatusHistory.AddAsync(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetOrderStatusByOrderIdAsync(int orderId)
        {
            var statuses = await _context.OrderStatusHistory.Where(x => x.OrderId == orderId).ToListAsync();
            return statuses;
        }
    }
}
