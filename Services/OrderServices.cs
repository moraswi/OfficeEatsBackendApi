﻿using AutoMapper;
using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Services
{
    public class OrderServices : IOrderServices
    {
        #region Fields
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public OrderServices(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        #endregion Public Constructors
        public async Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            order.OrderDate = DateTime.Now;
            order.OrderCode = GenerateOrderCode();

            //order.OrderStatusHistory = new OrderStatusHistory
            //{
            //    Status = "Pending",
            //    UpdatedBy = orderDto.UserId, // Adjust if needed
            //    UpdatedAt = DateTime.Now
            //};

            order.OrderStatusHistory = new List<OrderStatusHistory>
                    {
                        new OrderStatusHistory
                        {
                            Status = "Pending",
                            UpdatedBy = orderDto.UserId,
                            UpdatedAt = DateTime.Now
                        }
                    };


            var savedOrder = await _orderRepository.AddOrderAsync(order);

            return new ServiceResponse<Order>
            {
                Data = savedOrder,
                Success = true,
                Message = "Order placed successfully."
            };
        }


        public async Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId)
        {
            var results = await _orderRepository.GetAllOrdersByStoreIdAsync(storeId);
            return results;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var results = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return results;
        }

        //not working well
        public async Task<ServiceResponse<Order>> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = _mapper.Map<Order>(updateOrderDto);
     

            var updatedOrder = await _orderRepository.UpdateOrderAsync(order);

            return new ServiceResponse<Order>
            {
                Data = updatedOrder,
                Success = true,
                Message = "Order updated successfully."
            };
        }

        private string GenerateOrderCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 5)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            return $"#{code}";
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
           return await _orderRepository.GetOrderItemsByOrderIdAsync(orderId);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetDeliveryPatnerOfficePendingOrderAsync(int officeId)
        {
            return await _orderRepository.GetDeliveryPatnerOfficePendingOrderAsync(officeId);
        }

        public async Task<IEnumerable<Order>> GetDeliveryPatnerOrderAsync(int deliveryPartnerId)
        {
            return await _orderRepository.GetDeliveryPatnerOrderAsync(deliveryPartnerId);
        }

        public async Task<OrderStatusHistory> AddOrderStatusAsync(OrderStatusHistory status)
        {
            return await _orderRepository.AddOrderStatusAsync(status);
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetOrderStatusByOrderIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderStatusByOrderIdAsync(orderId);
        }
    }
}
