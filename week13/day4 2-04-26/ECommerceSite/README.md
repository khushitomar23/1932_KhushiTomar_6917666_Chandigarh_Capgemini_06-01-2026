# ECommerce Site - Complete Application Guide

## 🎨 Overview
A modern, minimal, and cute E-Commerce Web Application built with **.NET 9**, featuring:
- **Web API** (RESTful backend)
- **MVC Frontend** (cute UI with pastel colors & calligraphy fonts)
- **In-Memory Caching** (no Redis)
- **JWT Authentication** with Refresh Tokens
- **Role-based Authorization** (Admin/User)
- **Entity Framework Core** with Complex Relationships
- **FluentValidation** for input validation
- **AutoMapper** for DTOs
- **Repository Pattern** with Dependency Injection

---

## 📁 Project Structure

```
ECommerceSite/
├── ECommerceSite.API/                    # Web API
│   ├── Controllers/                      # API endpoints
│   │   ├── AuthController.cs            # Login, Register, JWT
│   │   ├── ProductsController.cs        # Product management
│   │   ├── OrdersController.cs          # Order management
│   │   └── CategoriesController.cs      # Category management
│   ├── Services/                        # Business logic
│   │   ├── AuthService.cs              # JWT token generation
│   │   ├── ProductService.cs           # Product operations
│   │   ├── OrderService.cs             # Order processing
│   │   └── ProductAndCategoryService.cs
│   ├── Repositories/                    # Data access layer
│   │   ├── GenericRepository.cs        # Base repository
│   │   ├── SpecificRepositories.cs     # User, Product, Order repos
│   │   └── Interfaces/
│   ├── Data/
│   │   └── AppDbContext.cs             # EF Core configuration
│   ├── Helpers/
│   │   └── JwtHelper.cs                # Token generation
│   ├── Middleware/
│   │   └── ExceptionMiddleware.cs      # Global error handling
│   ├── Validators/                     # FluentValidation rules
│   ├── Mappings/
│   │   └── MappingProfile.cs           # AutoMapper configurations
│   ├── appsettings.json
│   └── Program.cs                       # DI configuration
│
├── ECommerceSite.Models/                 # Shared models
│   ├── Entities/                        # Database entities
│   │   ├── User.cs (1-1 → UserProfile)
│   │   ├── UserProfile.cs
│   │   ├── Product.cs (M-M → Category)
│   │   ├── Category.cs
│   │   ├── ProductCategory.cs          # Join table for M-M
│   │   ├── Order.cs (1-M → OrderItem)
│   │   ├── OrderItem.cs
│   │   └── RefreshToken.cs
│   └── DTOs/                            # Data Transfer Objects
│       ├── AuthDtos.cs
│       ├── ProductDtos.cs
│       └── OrderDtos.cs
│
├── ECommerceSite.Web/                    # MVC Frontend
│   ├── Controllers/
│   │   └── HomeController.cs
│   ├── Views/
│   │   ├── Home/
│   │   │   ├── Index.cshtml            # Product listing
│   │   │   └── ProductDetails.cshtml   # Product details page
│   │   └── Shared/
│   │       └── _Layout.cshtml          # Master layout
│   ├── Services/
│   │   └── ApiService.cs               # HTTP client for API calls
│   ├── wwwroot/css/
│   │   └── site.css                    # Cute pastel styling
│   ├── appsettings.json
│   └── Program.cs
│
└── ECommerceSite.slnx                   # Solution file
```

---

## 🔐 Database Relationships

### 1️⃣ **One-to-One: User ↔ UserProfile**
```csharp
User: Id, Username, Email, PasswordHash, FullName
UserProfile: Id, Address, City, PostalCode, PhoneNumber, UserId
```

### 2️⃣ **One-to-Many: User → Order**
```csharp
User: 0..1 → ∞ Order
Each order belongs to one user
```

### 3️⃣ **Many-to-Many: Product ↔ Category**
```csharp
Product ← ProductCategory (join table) → Category
```

### 4️⃣ **One-to-Many: Order → OrderItem**
```csharp
Order: 1 → ∞ OrderItem
Each order has multiple items
```

---

## 🔑 Dependency Injection Lifetimes

| Scope | Usage | Example |
|-------|-------|---------|
| **Scoped** | Per HTTP request | DbContext, Repositories, Services |
| **Singleton** | Application lifetime | JwtHelper, IMemoryCache |
| **Transient** | New instance per use | (Not used in this project) |

**Why DbContext is Scoped?** To avoid data isolation issues per request.

---

## 🛡️ Authentication & Authorization

### JWT Flow:
```
1. User Login/Register → Generate Access Token + Refresh Token
2. Client sends Access Token in Authorization header
3. Server validates token → Allow/Deny access
4. Token expires after 1 hour
5. Use Refresh Token to get new Access Token
```

### Roles:
- **Admin**: Can create/update/delete products & categories, manage order status
- **User**: Can browse products, place orders, view own orders

---

## 💾 In-Memory Caching

Instead of Redis, uses `IMemoryCache` from Microsoft:

```csharp
// Get from cache or fetch from DB
if (_memoryCache.TryGetValue("products", out var data))
{
    return data;
}

// Cache with 10-minute expiration
_memoryCache.Set(key, data, new MemoryCacheEntryOptions()
{
    AbsoluteExpiration = TimeSpan.FromMinutes(10)
});
```

---

## 🎨 Frontend Features

### Cute Design:
- **Color Palette**: Pastel pink, purple, blue, peach, mint
- **Fonts**: Dancing Script (calligraphy), Caveat (headers), Quicksand (body)
- **Animations**: Hover effects, floating animations, smooth transitions
- **Responsive**: Mobile-friendly grid layout

### Pages:
1. **Home/Products** - Browse all products
2. **Product Details** - View full product info
3. **Cart** - (Ready to implement)
4. **Auth** - (Ready to implement)

---

## 🚀 Running the Application

### Prerequisites:
- .NET 9 SDK
- SQL Server (local or remote)
- Visual Studio 2022 or VS Code

### Steps:

1. **Update Database Connection**:
   ```json
   // ECommerceSite.API/appsettings.json
   "DefaultConnection": "Server=.;Database=ECommerceSiteDb;Trusted_Connection=True;TrustServerCertificate=True;"
   ```

2. **Create Database**:
   ```bash
   cd ECommerceSite.API
   dotnet ef database update
   ```

3. **Run Web API**:
   ```bash
   dotnet run --project ECommerceSite.API
   // Swagger: https://localhost:7001/
   ```

4. **Run Web Frontend** (new terminal):
   ```bash
   dotnet run --project ECommerceSite.Web
   // http://localhost:5273
   ```

---

## 📊 API Endpoints

### Authentication
- `POST /api/auth/login` - Login
- `POST /api/auth/register` - Register
- `POST /api/auth/refresh` - Refresh token
- `POST /api/auth/logout` - Logout

### Products
- `GET /api/products` - Get all (cached)
- `GET /api/products/{id}` - Get by ID
- `GET /api/products/search/{term}` - Search products
- `POST /api/products` - Create [Admin]
- `PUT /api/products/{id}` - Update [Admin]
- `DELETE /api/products/{id}` - Delete [Admin]

### Orders
- `POST /api/orders` - Create order [Authenticated]
- `GET /api/orders/{id}` - Get order details
- `GET /api/orders/my-orders` - My orders
- `PUT /api/orders/{id}/status` - Update status [Admin]

### Categories
- `GET /api/categories` - Get all (cached)
- `GET /api/categories/{id}` - Get by ID
- `POST /api/categories` - Create [Admin]
- `PUT /api/categories/{id}` - Update [Admin]
- `DELETE /api/categories/{id}` - Delete [Admin]

---

## 🧪 Testing with Swagger

1. Open: `https://localhost:7001/`
2. Click **Authorize** button
3. Login to get JWT token
4. Use token for subsequent requests

---

## 📚 Key Technologies

| Component | Technology |
|-----------|-----------|
| **Framework** | ASP.NET Core 9.0 |
| **Database** | SQL Server + EF Core |
| **Authentication** | JWT Bearer |
| **Validation** | FluentValidation |
| **Mapping** | AutoMapper |
| **Caching** | In-Memory Cache |
| **Frontend** | Razor Views + Bootstrap |
| **API Docs** | Swagger/OpenAPI |

---

## 🔧 Configuration Files

### appsettings.json (API)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ECommerceSiteDb;..."
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere",
    "Issuer": "ECommerceSite",
    "Audience": "ECommerceSiteUsers"
  }
}
```

---

## 📝 Interview Questions & Answers

### 1. What is Dependency Injection?
**DI provides dependencies from outside**, enabling loose coupling and testability.

### 2. Why is DbContext Scoped?
**Per-request isolation** prevents cross-request data contamination.

### 3. Difference between Scoped and Singleton?
- **Scoped**: New per request (DbContext)
- **Singleton**: One throughout app lifetime (Cache)

### 4. What is JWT?
**JSON Web Token** - stateless authentication with claims (user ID, role, etc.)

### 5. Why use DTOs instead of Entities?
**Security & contracts** - don't expose DB structure, decouple API from data model.

### 6. What is AutoMapper?
**Maps entities to DTOs** automatically, reducing boilerplate.

### 7. How does In-Memory Caching work?
**Stores data in application memory** with optional expiration, faster than DB.

### 8. What is Repository Pattern?
**Abstracts data access**, making code testable and maintainable.

### 9. Role-Based Authorization?
**Restrict endpoints based on user role** (Admin, User, etc.)

### 10. What is FluentValidation?
**Fluent API for validation rules**, provides automatic model validation.

---

## 🐛 Common Mistakes Avoided

✅ Using Scoped DbContext (not Singleton)  
✅ DTOs instead of exposing entities  
✅ Global exception middleware  
✅ Proper JWT token validation  
✅ Role-based authorization checks  
✅ In-memory cache invalidation on updates  

---

## 🚦 Next Steps (Optional Enhancements)

1. **Shopping Cart** - Session-based or database
2. **Payment Gateway** - Stripe/PayPal integration
3. **Email Notifications** - Order confirmation emails
4. **Admin Dashboard** - Analytics & reports
5. **Product Reviews** - User ratings
6. **Wishlist** - Save favorites
7. **Unit Tests** - xUnit + Moq
8. **Docker** - Containerization
9. **Azure Deployment** - Cloud hosting
10. **SignalR** - Real-time notifications

---

## 📞 Support

For questions or issues, refer to:
- Swagger API docs: `https://localhost:7001/`
- Database schema in `AppDbContext.cs`
- Service layer in `Services/` folder
- Controller implementations in `Controllers/` folder

---

**Happy coding! 🎉 This is a production-ready foundation you can build upon!**
