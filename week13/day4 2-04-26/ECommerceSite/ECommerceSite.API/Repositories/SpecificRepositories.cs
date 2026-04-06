using Microsoft.EntityFrameworkCore;
using ECommerceSite.API.Data;
using ECommerceSite.Models.Entities;
using ECommerceSite.API.Repositories.Interfaces;

namespace ECommerceSite.API.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserWithProfileAsync(int userId)
        {
            return await _dbSet.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWithCategoriesAsync(int productId)
        {
            return await _dbSet
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Include(p => p.ProductCategories)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _dbSet
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToListAsync();
        }
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
        {
            return await _dbSet
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }

    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetValidTokenAsync(string token)
        {
            return await _dbSet.FirstOrDefaultAsync(rt => rt.Token == token && !rt.IsRevoked && rt.ExpiryDate > DateTime.UtcNow);
        }

        public async Task RevokeTokenAsync(string token)
        {
            var refreshToken = await _dbSet.FirstOrDefaultAsync(rt => rt.Token == token);
            if (refreshToken != null)
            {
                refreshToken.IsRevoked = true;
                _context.Update(refreshToken);
                await _context.SaveChangesAsync();
            }
        }
    }
}
