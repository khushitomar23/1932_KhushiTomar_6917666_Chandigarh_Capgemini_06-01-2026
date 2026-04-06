# 🚀 ECommerce Site - Quick Start Guide

## ⚡ 5-Minute Setup

### Step 1: Verify Database Connection
Edit `ECommerceSite.API/appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ECommerceSiteDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Step 2: Create Database
```bash
cd ECommerceSite/ECommerceSite.API
dotnet ef database update
```

### Step 3: Run Web API
```bash
dotnet run
```
✅ **Swagger UI**: https://localhost:7001/

### Step 4: Run MVC Frontend (New Terminal)
```bash
cd ECommerceSite/ECommerceSite.Web
dotnet run
```
✅ **Frontend**: http://localhost:5273

---

## 🧪 Testing the API

### 1️⃣ Register User
```bash
POST https://localhost:7001/api/auth/register

{
  "username": "admin",
  "email": "admin@example.com",
  "password": "Admin@123",
  "fullName": "Admin User"
}
```

**Response**:
```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIs...",
  "refreshToken": "base64encodedtoken...",
  "expiresIn": "2026-04-03T13:00:00Z"
}
```

### 2️⃣ Login
```bash
POST https://localhost:7001/api/auth/login

{
  "username": "admin",
  "password": "Admin@123"
}
```

### 3️⃣ Create Product (Admin)
Copy `accessToken` from login response, then:

```bash
POST https://localhost:7001/api/products

Header: Authorization: Bearer <accessToken>

{
  "name": "Beautiful Notebook",
  "description": "A cute handmade notebook with calligraphy design",
  "price": 599.99,
  "stockQuantity": 50
}
```

### 4️⃣ Get All Products
```bash
GET https://localhost:7001/api/products
```
✅ Results are cached for 10 minutes!

### 5️⃣ Place Order
```bash
POST https://localhost:7001/api/orders

Header: Authorization: Bearer <accessToken>

{
  "items": [
    {
      "productId": 1,
      "quantity": 2
    }
  ]
}
```

---

## 🎨 Frontend Features

### Products Page
- Browse all products with cute cards
- See product details, price, stock status
- Click "View Details" for full information

### Product Details Page
- Full product description
- Price and stock information
- Categories
- Add to Cart button (placeholder)

### Cute Styling
- **Colors**: Pastel pink, purple, blue, peach, mint
- **Fonts**: Dancing Script (headers), Quicksand (body)
- **Responsive**: Works on mobile, tablet, desktop

---

## 📌 Key Features Implemented

### ✅ Backend (API)
- [x] JWT Authentication & Authorization
- [x] Role-based Access (Admin/User)
- [x] Refresh Token System
- [x] In-Memory Caching (10-min products)
- [x] Global Exception Handling
- [x] Auto-generated Swagger Docs
- [x] FluentValidation
- [x] AutoMapper
- [x] Repository Pattern
- [x] Dependency Injection

### ✅ Database
- [x] Complex Relationships (1-1, 1-M, M-M)
- [x] User Authentication
- [x] Product Management
- [x] Order Processing
- [x] Category Management

### ✅ Frontend (MVC)
- [x] Cute Pastel Design
- [x] Calligraphy Fonts
- [x] Responsive Layout
- [x] Product Listing
- [x] Product Details Page
- [x] API Integration

---

## 🔐 Test Admin Credentials

After first registration, use:
```
Username: admin
Password: Admin@123
Role: Admin (can manage products)
```

---

## 📡 API Response Examples

### Success Response
```json
{
  "id": 1,
  "name": "Product Name",
  "price": 599.99,
  "stockQuantity": 50,
  "description": "Product description",
  "categories": ["category1", "category2"]
}
```

### Error Response
```json
{
  "message": "Product not found",
  "type": "KeyNotFoundException"
}
```

---

## 🔄 Entity Relationships Diagram

```
User (1) ──────────── (1) UserProfile
  │
  ├─────────────────────────────────────────────────────┐
  │                                                     │
  │                                         ┌───────────┴───────────┐
  │                                         │                       │
Order (1) ──── (M) OrderItem ── (M) Product ── (M) Category
  │
  └──────────────────── (M) RefreshToken
```

---

## ⚙️ Lifetime Configuration

| Component | Lifetime | Why |
|-----------|----------|-----|
| DbContext | Scoped | Per-request isolation |
| IAuthService | Scoped | Uses DbContext |
| IProductService | Scoped | Uses DbContext |
| JwtHelper | Singleton | Stateless, reusable |
| IMemoryCache | Singleton | Shared cache |

---

## 🛠️ Troubleshooting

### Issue: "Database does not exist"
**Solution**: Run `dotnet ef database update`

### Issue: "Invalid JWT token"
**Solution**: Ensure token hasn't expired, use refresh endpoint

### Issue: "Stock quantity reduced on failed order"
**Solution**: Use transactions (implement in next version)

### Issue: "Cache not invalidating"
**Solution**: Cache automatically clears after 10 mins or on create/update/delete

---

## 📚 Code Organization

```
Architecture:
Controller → Service → Repository → DbContext → Database

Flow:
API Request → Validation → Service Logic → DB Query → Cache → Response
```

---

## 🎯 Next Implementations

1. **Shopping Cart** - Session storage
2. **Order History** - User dashboard
3. **Admin Panel** - Manage products/orders
4. **Payment** - Stripe integration
5. **Email** - Order notifications
6. **Reviews** - Product ratings
7. **Search** - Full-text search
8. **Filters** - By category, price, rating
9. **Wishlist** - Save favorites
10. **Real-time** - SignalR notifications

---

## 📞 Common Operations

### Add New Product
1. Login as Admin
2. POST /api/products with product details
3. See in products list immediately (after cache clears)

### Place Order
1. Login as User
2. POST /api/orders with product IDs and quantities
3. Stock automatically reduces
4. View in /api/orders/my-orders

### Change Order Status
1. Login as Admin
2. PUT /api/orders/{id}/status with new status
3. Statuses: Pending, Processing, Shipped, Delivered

---

**Start building! Good luck! 🎉**
