﻿using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

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
            var results = await _context.Order.Where(x => x.ShopId == storeId).ToListAsync();
            return results;
        }


        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var results = await _context.Order.Where(x => x.UserId == userId).ToListAsync();
            return results;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
