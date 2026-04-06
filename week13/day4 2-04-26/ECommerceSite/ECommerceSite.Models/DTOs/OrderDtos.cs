namespace ECommerceSite.Models.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }

    public class CreateOrderDto
    {
        public List<OrderItemRequestDto> Items { get; set; } = new List<OrderItemRequestDto>();
    }

    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class OrderItemRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
