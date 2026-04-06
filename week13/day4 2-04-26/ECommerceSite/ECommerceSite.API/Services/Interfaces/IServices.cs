using ECommerceSite.Models.DTOs;

namespace ECommerceSite.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
        Task<TokenResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<TokenResponseDto> RefreshTokenAsync(string refreshToken);
        Task RevokeTokenAsync(string refreshToken);
    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int productId, CreateProductDto productDto);
        Task DeleteProductAsync(int productId);
        Task<List<ProductDto>> SearchProductsAsync(string searchTerm);
    }

    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto orderDto);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<List<OrderDto>> GetUserOrdersAsync(int userId);
        Task UpdateOrderStatusAsync(int orderId, string status);
    }

    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task UpdateCategoryAsync(int categoryId, CreateCategoryDto categoryDto);
        Task DeleteCategoryAsync(int categoryId);
    }
}
