using Moq;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.API.Controllers;
using OrderProcessing.API.Models;
using OrderProcessing.API.Services;
using Xunit;

namespace OrderProcessing.Tests.xUnit
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _mockService;
        private readonly OrderController _controller;

        //  xUnit uses Constructor for setup
        public OrderControllerTests()
        {
            _mockService = new Mock<IOrderService>();
            _controller = new OrderController(_mockService.Object);
        }

        //  Test 1: Valid Order → 201 Created
        [Fact]
        public async Task PlaceOrder_ReturnsCreated_WhenOrderIsValid()
        {
            // Arrange — prepare a valid order
            var validOrder = new Order
            {
                Id = 1,
                CustomerName = "Khushi",
                ProductName = "Laptop",
                Quantity = 2,
                TotalPrice = 1999.98m
            };

            // Tell mock: when PlaceOrderAsync is called → return true
            _mockService
                .Setup(s => s.PlaceOrderAsync(validOrder))
                .ReturnsAsync(true);

            // Act — call the controller method
            var result = await _controller.PlaceOrder(validOrder);

            // Assert — must be 201 Created
            Assert.IsType<CreatedResult>(result);
        }

        //  Test 2: Invalid Order → 400 Bad Request
        [Fact]
        public async Task PlaceOrder_ReturnsBadRequest_WhenOrderIsInvalid()
        {
            // Arrange — prepare an invalid order
            var invalidOrder = new Order
            {
                Id = 2,
                CustomerName = "",
                ProductName = "",
                Quantity = 0,
                TotalPrice = 0
            };

            // Tell mock: when PlaceOrderAsync is called → return false
            _mockService
                .Setup(s => s.PlaceOrderAsync(invalidOrder))
                .ReturnsAsync(false);

            // Act — call the controller method
            var result = await _controller.PlaceOrder(invalidOrder);

            // Assert — must be 400 Bad Request
            Assert.IsType<BadRequestResult>(result);
        }
    }
}