namespace ECommerceSite.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Many-to-One with Order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        // Many-to-One with Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
