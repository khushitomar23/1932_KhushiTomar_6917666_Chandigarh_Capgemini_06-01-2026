namespace ECommerceSite.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/400x400?text=Product";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Many-to-Many relationship
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        // One-to-Many relationship with OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
