# 🚀 Quick Start Guide

## For Beginners

### Step 1: Clone/Download the Project
Navigate to your project folder where both HealthcareAPI and HealthcareMVC are present.

### Step 2: Create the Database

**Using SSMS (SQL Server Management Studio):**
1. Open SSMS
2. Connect to your SQL Server: `KHUSHI23\SQLEXPRESS`
3. Open the file: `Database/HealthcareDB_Schema.sql`
4. Click **Execute** (or press F5)
5. Database created! ✅

### Step 3: Run the API

**Using Command Prompt:**
```bash
cd HealthcareAPI
dotnet run
```

API will start at: `https://localhost:7101`

**Using Visual Studio:**
1. Open the solution
2. Set HealthcareAPI as startup project
3. Press F5 to run

### Step 4: Run the MVC (in another terminal/window)

**Using Command Prompt:**
```bash
cd HealthcareMVC
dotnet run
```

MVC will start at: `https://localhost:7100` or similar

**Using Visual Studio:**
1. Keep API running
2. Right-click solution → Add → Existing Project
3. Add HealthcareMVC
4. In Solution Explorer, right-click HealthcareMVC → Set as Startup Project (or use multi-startup projects)
5. Press F5

### Step 5: Use the Application

1. Open browser to: `https://localhost:7100` (or the port shown)
2. Click **Register** to create a new account
3. Login with your credentials
4. Browse doctors and book appointments
5. View your appointments

## 🧪 Testing the API Directly

### Register User
```bash
curl -X POST https://localhost:7101/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "fullName": "John Doe",
    "email": "john@example.com",
    "password": "password123",
    "role": "Patient"
  }'
```

### Login
```bash
curl -X POST https://localhost:7101/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "password123"
  }'
```

### Get All Doctors
```bash
curl -X GET https://localhost:7101/api/doctors
```

### Book Appointment
```bash
curl -X POST https://localhost:7101/api/appointments/book?patientId=5 \
  -H "Content-Type: application/json" \
  -d '{
    "doctorId": 1,
    "appointmentDate": "2025-04-10T10:00:00"
  }'
```

## Sample Accounts for Testing

| Email | Password | Role | Status |
|-------|----------|------|--------|
| admin@healthcare.com | * | Admin | Created from schema |
| john.patient@healthcare.com | * | Patient | Created from schema |

*Password hashes are created from schema. Create new accounts using Register feature.*

## 🎨 Customization

### Change Colors
Edit `HealthcareMVC/wwwroot/css/style.css` - look for `:root` variables:
```css
:root {
    --primary: #ff1493;      /* Main pink */
    --secondary: #ffc0cb;    /* Light pink */
    --dark: #2d3436;         /* Dark text */
    --light: #f5f5f5;        /* Light bg */
}
```

### Change Fonts
Update Google Fonts imports in `_Layout.cshtml`:
```html
<link href="https://fonts.googleapis.com/css2?family=YOUR_FONT&display=swap" rel="stylesheet">
```

### Change API URL
In `HealthcareMVC/Controllers/*`, update:
```csharp
private const string ApiBaseUrl = "https://localhost:7101/api";
```

## 📊 Database Status Check

**To verify database was created:**
1. Open SSMS
2. Connect to `KHUSHI23\SQLEXPRESS`
3. Expand **Databases**
4. Look for **HealthcareDB**
5. Expand it to see tables (Users, Doctors, Appointments, etc.)

## ✅ Common Checks

- [ ] SQL Server is running
- [ ] Database HealthcareDB exists
- [ ] Both API and MVC projects have .NET 8.0
- [ ] API runs on port 7101
- [ ] MVC can reach API endpoint
- [ ] SSL certificates are trusted (Dev environment)

## 🆘 If Something Goes Wrong

### API won't start
```bash
# Clear cache
cd HealthcareAPI
rmdir bin obj /s /q
dotnet restore
dotnet run
```

### Database errors
- Verify connection string in `Program.cs`
- Re-run the SQL schema script
- Check SQL Server service is running

### Port Already in Use
```bash
# Find what's using port 7101
netstat -ano | findstr :7101

# Kill the process (replace PID with number from above)
taskkill /PID <PID> /F
```

### MVC can't reach API
- Verify API is running at `https://localhost:7101`
- Check firewall permissions
- Verify CORS is enabled in API

## 📞 Need Help?

Check the full README.md for more details on API endpoints, database schema, and features.

---

**Happy Coding! 💕**
