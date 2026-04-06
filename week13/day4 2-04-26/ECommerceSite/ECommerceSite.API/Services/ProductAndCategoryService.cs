using AutoMapper;
using ECommerceSite.API.Repositories.Interfaces;
using ECommerceSite.API.Services.Interfaces;
using ECommerceSite.Models.DTOs;
using ECommerceSite.Models.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace ECommerceSite.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private const string PRODUCTS_CACHE_KEY = "all_products";

        public ProductService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IMemoryCache memoryCache)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            if (_memoryCache.TryGetValue(PRODUCTS_CACHE_KEY, out List<ProductDto> cachedProducts))
            {
                return cachedProducts;
            }

            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set(PRODUCTS_CACHE_KEY, productDtos, cacheOptions);

            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductWithCategoriesAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            InvalidateProductCache();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int productId, CreateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _mapper.Map(productDto, product);
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            InvalidateProductCache();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();

            InvalidateProductCache();
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            var products = await _productRepository.SearchProductsAsync(searchTerm);
            return _mapper.Map<List<ProductDto>>(products);
        }

        private void InvalidateProductCache()
        {
            _memoryCache.Remove(PRODUCTS_CACHE_KEY);
        }
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private const string CATEGORIES_CACHE_KEY = "all_categories";

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            if (_memoryCache.TryGetValue(CATEGORIES_CACHE_KEY, out List<CategoryDto> cachedCategories))
            {
                return cachedCategories;
            }

            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set(CATEGORIES_CACHE_KEY, categoryDtos, cacheOptions);

            return categoryDtos;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            InvalidateCategoryCache();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(int categoryId, CreateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(categoryDto, category);
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            InvalidateCategoryCache();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();

            InvalidateCategoryCache();
        }

        private void InvalidateCategoryCache()
        {
            _memoryCache.Remove(CATEGORIES_CACHE_KEY);
        }
    }
}
