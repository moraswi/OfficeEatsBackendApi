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

        #endregion Public Constructors
        public async Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

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

    }
}
