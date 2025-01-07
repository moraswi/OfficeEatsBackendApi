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
            //var results = await _context.Order.Where(x => x.ShopId == storeId).ToListAsync();
            var results = await _context.Order
                        .Where(x => x.ShopId == storeId && x.OrderStatus != "Completed" && x.OrderStatus != "Declined")
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
            var results = await _context.Order.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == orderId);
            return results;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var results = await _context.Order
                .Include(o => o.Items)
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
                .Where(x => x.OfficeId == officeId &&
                            (x.OrderStatus != "Pending" &&
                             x.OrderStatus != "Declined" &&
                             x.OrderStatus != "Completed"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetDeliveryPatnerOrderAsync(int deliveryPartnerId)
        {
             return await _context.Order
                .Where(x => x.DeliveryPartnerId == deliveryPartnerId &&
                            x.OrderStatus != "Completed")
                .ToListAsync();
        }
    }
}
