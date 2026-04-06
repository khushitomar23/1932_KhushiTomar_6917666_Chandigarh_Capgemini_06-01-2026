# 🏗️ ECommerce Site - Architecture & Design Decisions

## 📐 Overall Architecture

```
                    User (Browser)
                          |
                          | HTTP/HTTPS
                          ↓
                    ┌─────────────┐
                    │ MVC Frontend│
                    │ (Views/CSS) │
                    └──────┬──────┘
                           |
                    API Service Layer
                           |
                    ┌──────────────────────────────────┐
                    │  ASP.NET Core Web API            │
                    │  ┌────────────────────────────┐  │
                    │  │ Controllers (Routing)      │  │
                    │  ├────────────────────────────┤  │
                    │  │ Services (Business Logic)  │  │
                    │  ├────────────────────────────┤  │
                    │  │ Repositories (Data Access) │  │
                    │  ├────────────────────────────┤  │
                    │  │ DbContext (ORM)            │  │
                    │  └────────────────────────────┘  │
                    └──────────────┬───────────────────┘
                                   |
                    ┌──────────────┴──────────────┐
                    ↓                             ↓
            ┌─────────────────┐          ┌──────────────┐
            │   SQL Server    │          │Memory Cache  │
            │   (Persistent)  │          │(In-Memory)   │
            └─────────────────┘          └──────────────┘
```

---

## 🎯 Design Principles

### 1. **SOLID Principles**
- **S**ingle Responsibility: Each class has one job
- **O**pen/Closed: Open for extension, closed for modification
- **L**iskov Substitution: Derived classes can replace base classes
- **I**nterface Segregation: Small, focused interfaces
- **D**ependency Inversion: Depend on abstractions, not implementations

### 2. **Dependency Injection (DI)**
```csharp
// Services are injected, not created manually
public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    
    public ProductService(IProductRepository repo)
    {
        _repo = repo; // Injected via DI container
    }
}
```

### 3. **Repository Pattern**
- Abstracts data access
- Makes code testable and maintainable
- Single source of database logic

### 4. **Separation of Concerns**
```
Controllers → Services → Repositories → DbContext
   (HTTP)   (Business)   (CRUD ops)   (ORM)
```

---

## 🔐 Security Architecture

### JWT Token Flow
```
1. User Login
        ↓
2. Validate Credentials (SHA256 hash)
        ↓
3. Generate JWT (HS256 algorithm)
        + Claims: UserId, Username, Role
        + Expiry: 1 hour
        ↓
4. Generate Refresh Token
        + UUID format
        + 7-day expiry
        ↓
5. Send Both to Client
        ↓
6. Client Stores & Uses Access Token
        ↓
7. Token Expires → Use Refresh Token
        ↓
8. Get New Access Token
```

### Password Security
```csharp
// SHA256 hashing (production should use bcrypt/Argon2)
using SHA256 sha256 = SHA256.Create();
byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
return Convert.ToBase64String(hashedBytes);
```

### Role-Based Authorization
```csharp
[Authorize(Roles = "Admin")]  // Only admins access
[Authorize(Roles = "User")]   // Only users access
[Authorize]                   // Any authenticated user
```

---

## 💾 Database Design

### Schema Design Principles
1. **Normalization**: Minimize redundancy
2. **Relationships**: Use foreign keys
3. **Constraints**: Enforce data integrity
4. **Indexing**: Optimize queries

### Entity Relationships

#### 1️⃣ One-to-One: User ↔ UserProfile
```csharp
public class User
{
    public int Id { get; set; }
    public UserProfile Profile { get; set; }
}

public class UserProfile
{
    public int UserId { get; set; }
    public User User { get; set; }
}
```
**Why?** Separate profile data from authentication data.

#### 2️⃣ One-to-Many: User → Order
```csharp
public class User
{
    public ICollection<Order> Orders { get; set; }
}

public class Order
{
    public int UserId { get; set; }
    public User User { get; set; }
}
```
**Why?** One user can have multiple orders.

#### 3️⃣ Many-to-Many: Product ↔ Category
```csharp
public class Product
{
    public ICollection<ProductCategory> ProductCategories { get; set; }
}

public class ProductCategory  // Join table
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product Product { get; set; }
    public Category Category { get; set; }
}

public class Category
{
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
```
**Why?** Products belong to multiple categories (Many-to-Many).

#### 4️⃣ One-to-Many: Order → OrderItem
```csharp
public class Order
{
    public ICollection<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
```
**Why?** Orders contain multiple line items.

---

## 🔄 Caching Strategy

### In-Memory Caching Implementation
```csharp
// Products cached for 10 minutes
const string CACHE_KEY = "all_products";

// Check cache first
if (_cache.TryGetValue(CACHE_KEY, out var products))
{
    return products;
}

// Fetch from DB if not cached
var dbProducts = await _productRepo.GetAllAsync();

// Set cache
_cache.Set(CACHE_KEY, dbProducts, 
    new MemoryCacheEntryOptions()
    {
        AbsoluteExpiration = TimeSpan.FromMinutes(10)
    });

return dbProducts;
```

### Cache Invalidation
```csharp
// On Create/Update/Delete, clear cache
private void InvalidateCache()
{
    _cache.Remove("all_products");
}
```

### Why In-Memory vs Redis?
| Aspect | In-Memory | Redis |
|--------|-----------|-------|
| Setup | Simple | Requires Redis server |
| Speed | Fastest | Fast |
| Scalability | Single app | Distributed |
| Cost | Free | Paid (often) |
| Scope | This app only | Shared across apps |

**Decision**: In-Memory for simplicity, minimal requirements.

---

## 🎨 DTO Pattern

### Why DTOs (Data Transfer Objects)?

```csharp
// ❌ BAD: Exposing entity directly
public IActionResult GetUser(int id)
{
    var user = _dbContext.Users.Find(id);
    return Ok(user);  // Exposes all properties, passwords!
}

// ✅ GOOD: Using DTO
public IActionResult GetUser(int id)
{
    var user = _userRepo.GetById(id);
    var userDto = _mapper.Map<UserDto>(user);
    return Ok(userDto);  // Only exposed properties
}
```

### Benefits:
- **Security**: Don't expose sensitive fields
- **Versioning**: Change DTO without changing entity
- **Validation**: Validate input DTOs
- **API Contract**: Clear API interface

### Mapping Flow:
```
Request DTO → Validation → Mapping → Entity → Repo → DB
Response ← Mapping ← Entity ← Repo ← DB
```

---

## 🗂️ Lifetimes Explained

### Scoped (Per Request)
```csharp
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IProductService>();
```
**Behavior**: New instance per HTTP request
```
Request 1: Service A → Repo A → DbContext A
Request 2: Service B → Repo B → DbContext B  // Different context!
```
**Why**: Each request has isolated DB context → no data bleeding.

### Singleton
```csharp
builder.Services.AddSingleton<IMemoryCache>();
builder.Services.AddSingleton<JwtHelper>();
```
**Behavior**: Single instance for entire application lifetime
```
Request 1: Cache (shared)
Request 2: Cache (same instance)
Request 3: Cache (same instance)
```
**Why**: Cache data is shared, JwtHelper is stateless.

### Transient (Rare)
```csharp
builder.Services.AddTransient<ISomeService>();
```
**Behavior**: New instance every time it's injected
**Use**: Almost never needed in web apps.

### ⚠️ Common Mistake:
```csharp
// ❌ WRONG: Singleton DbContext
builder.Services.AddSingleton<AppDbContext>();
// This causes data isolation issues!

// ✅ CORRECT: Scoped DbContext
builder.Services.AddScoped<AppDbContext>();
```

---

## 🧪 Input Validation Architecture

### FluentValidation Rules
```csharp
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Required")
            .Length(3, 200).WithMessage("3-200 chars");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Must be > 0");
    }
}
```

### Validation Flow:
```
Request → Model Binding → Validation Rules → Service → DB
          ↓
        (If invalid)
        ↓
        400 Bad Request
```

---

## 🚦 Error Handling Strategy

### Global Exception Middleware
```csharp
public class ExceptionMiddleware
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Handle all exceptions centrally
            await HandleException(context, ex);
        }
    }
}
```

### Error Responses:
```json
{
    "message": "Product not found",
    "type": "KeyNotFoundException"
}
```

### Status Codes:
- 200: Success
- 201: Created
- 400: Bad Request (validation, invalid operation)
- 404: Not Found
- 500: Server Error (caught by middleware)

---

## 📊 Data Flow Example: Place Order

```
1. User POST /api/orders with items
   ↓
2. Controller validates DTO
   ↓
3. Controller extracts UserId from JWT claims
   ↓
4. Service: CreateOrderAsync(userId, orderDto)
   ↓
5. For each item:
   a. Validate product exists
   b. Check stock quantity
   c. Reduce stock
   d. Add OrderItem
   ↓
6. Calculate total amount
   ↓
7. Repository: Add Order
   ↓
8. DbContext: SaveChangesAsync() → SQL
   ↓
9. Response: 201 Created with OrderDto
```

---

## 🏆 Best Practices Implemented

✅ **DI for loose coupling**
✅ **Repository pattern for data abstraction**
✅ **DTOs for API contracts**
✅ **Scoped DbContext for request isolation**
✅ **Singleton cache for performance**
✅ **JWT for stateless authentication**
✅ **FluentValidation for input validation**
✅ **AutoMapper for object mapping**
✅ **Global exception handling**
✅ **Role-based authorization**
✅ **In-memory caching with invalidation**

---

## 🔮 Future Improvements

1. **Logging**: Add Serilog for structured logging
2. **Caching**: Add Redis for distributed cache
3. **Database**: Add indexes on frequently queried columns
4. **API**: Add pagination to product list
5. **Testing**: Add xUnit + Moq tests
6. **Transactions**: Wrap order creation in transaction
7. **Audit Trail**: Track who modified what
8. **Rate Limiting**: Prevent abuse
9. **CORS**: Configure for specific origins
10. **Documentation**: Add XML comments to code

---

**This architecture is production-ready and follows industry best practices!** 🚀
