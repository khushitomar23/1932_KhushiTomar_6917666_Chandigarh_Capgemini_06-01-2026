using Microsoft.AspNetCore.Mvc;
using OrderProcessing.API.Models;
using OrderProcessing.API.Services;

namespace OrderProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] Order order)
        {
            var success = await _orderService.PlaceOrderAsync(order);

            if (!success)
                return BadRequest();       // 400 

            return Created("", order);     // 201 
        }
    }
}