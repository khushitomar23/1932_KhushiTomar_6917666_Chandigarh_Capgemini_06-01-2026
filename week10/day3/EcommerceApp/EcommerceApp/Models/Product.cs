namespace EcommerceApp.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // navigation
    public ICollection<OrderDetail> OrderDetails { get; set; }
  }
}