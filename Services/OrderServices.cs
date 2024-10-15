using AutoMapper;
using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

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

        public async Task<IEnumerable<Order>> GetAllOrdersByStoreIdAsync(int storeId)
        {
            var results = await _orderRepository.GetAllOrdersByStoreIdAsync(storeId);
            return results;
        }

        #endregion Public Constructors
        public async Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                UserId = orderDto.UserId,
                DeliveryAddress = orderDto.DeliveryAddress,
                Items = orderDto.Items.Select(i => new OrderItem
                {
                    Id = i.FoodItemId,
                    Quantity = i.Quantity,
                    UnitPrice = 100000,
                    TotalPrice = i.Quantity * 10
                }).ToList()
            };

            order.TotalAmount = order.Items.Sum(i => i.TotalPrice);

            var savedOrder = await _orderRepository.AddOrderAsync(order);

            return new ServiceResponse<Order> { Data = savedOrder, Success = true, Message = "Order placed successfully." };
        }

    }
}
