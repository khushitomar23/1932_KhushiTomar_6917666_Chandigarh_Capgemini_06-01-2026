using OrderProcessing.API.Models;

namespace OrderProcessing.API.Services
{
    public class OrderService : IOrderService
    {
        public Task<bool> PlaceOrderAsync(Order order)
        {
            //  Invalid if name empty or quantity is 0
            if (string.IsNullOrWhiteSpace(order.CustomerName) ||
                string.IsNullOrWhiteSpace(order.ProductName) ||
                order.Quantity <= 0)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true); //  Success
        }
    }
}