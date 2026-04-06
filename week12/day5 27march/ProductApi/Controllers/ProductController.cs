using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IMemoryCache _cache;

    public ProductController(IMemoryCache cache)
    {
        _cache = cache;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        string cacheKey = "product_list";

        if (!_cache.TryGetValue(cacheKey, out List<string> products))
        {
            // Simulate DB delay
            Thread.Sleep(3000);

            products = new List<string>
            {
                "Laptop", "Mobile", "Tablet", "Headphones"
            };

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            _cache.Set(cacheKey, products, options);
        }

        return Ok(products);
    }
}