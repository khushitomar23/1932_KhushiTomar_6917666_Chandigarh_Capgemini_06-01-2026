using AutoMapper;
using ECommerceSite.API.Repositories.Interfaces;
using ECommerceSite.API.Services.Interfaces;
using ECommerceSite.Models.DTOs;
using ECommerceSite.Models.Entities;

namespace ECommerceSite.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto orderDto)
        {
            if (orderDto.Items == null || orderDto.Items.Count == 0)
            {
                throw new InvalidOperationException("Order must contain at least one item");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            decimal totalAmount = 0;

            foreach (var item in orderDto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with id {item.ProductId} not found");
                }

                if (product.StockQuantity < item.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient stock for product {product.Name}");
                }

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    TotalPrice = product.Price * item.Quantity
                };

                order.OrderItems.Add(orderItem);
                totalAmount += orderItem.TotalPrice;

                // Reduce stock
                product.StockQuantity -= item.Quantity;
                _productRepository.Update(product);
            }

            order.TotalAmount = totalAmount;

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderWithItemsAsync(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetUserOrdersAsync(int userId)
        {
            var orders = await _orderRepository.GetUserOrdersAsync(userId);
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            order.Status = status;
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
