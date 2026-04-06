using ECommerceSite.Models.Entities;

namespace ECommerceSite.API.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetUserWithProfileAsync(int userId);
    }

    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductWithCategoriesAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    }

    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
    }

    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }

    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken> GetValidTokenAsync(string token);
        Task RevokeTokenAsync(string token);
    }
}
