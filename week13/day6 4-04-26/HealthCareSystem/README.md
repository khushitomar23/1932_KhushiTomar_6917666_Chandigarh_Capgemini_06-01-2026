# 🏥 Healthcare Appointment System

A beautiful, minimal healthcare appointment booking application built with ASP.NET Core and MVC. Features a cute, calligraphy-inspired interface with full CRUD operations for managing doctors, appointments, prescriptions, and billing.

## 🌸 Features

- **User Authentication**: Secure login and registration system
- **Doctor Listing**: Browse all available doctors by specialty
- **Appointment Booking**: Easy-to-use appointment scheduling
- **Appointment Management**: View, cancel appointments
- **Beautiful UI**: Cute, minimal design with calligraphy fonts
- **Responsive Design**: Works on desktop, tablet, and mobile

## 📋 Project Structure

```
HealthcareAppointmentSystem/
├── HealthcareAPI/           # ASP.NET Core Web API
│   ├── Models/              # Data models
│   ├── Controllers/         # API endpoints
│   ├── Services/            # Business logic
│   ├── Repositories/        # Data access layer
│   ├── Data/               # DbContext
│   ├── DTOs/               # Data transfer objects
│   └── Program.cs          # Configuration
├── HealthcareMVC/          # ASP.NET Core MVC Frontend
│   ├── Controllers/        # MVC controllers
│   ├── Models/             # View models
│   ├── Views/              # Razor views
│   ├── wwwroot/            # Static files (CSS, JS)
│   └── Program.cs          # Configuration
└── Database/               # SQL Server scripts
    └── HealthcareDB_Schema.sql
```

## 🗄️ Database Schema

### Tables
- **Users**: Store user info (patients, doctors, admins)
- **Departments**: Medical departments/specialties
- **Doctors**: Doctor information with department reference
- **Appointments**: Patient-doctor appointment records
- **Prescriptions**: Medical prescriptions (1-1 with Appointments)
- **Bills**: Appointment billing and payments

### Relationships
- User → Doctor (1-1)
- Department → Doctor (1-M)
- User (Patient) → Appointment (1-M)
- Doctor → Appointment (1-M)
- Appointment → Prescription (1-1)
- Appointment → Bill (1-1)

## 🚀 Setup Instructions

### Prerequisites
- .NET 8.0 SDK
- SQL Server (Server: `KHUSHI23\SQLEXPRESS`)
- Visual Studio Code or Visual Studio 2022

### Step 1: Setup Database

1. Open SQL Server Management Studio (SSMS)
2. Connect to `KHUSHI23\SQLEXPRESS`
3. Open `Database/HealthcareDB_Schema.sql`
4. Execute the script to create the database with all tables and sample data

### Step 2: Configure API

1. Navigate to `HealthcareAPI` folder
2. Update connection string in `Program.cs` if needed:
   ```csharp
   var connectionString = "Server=KHUSHI23\\SQLEXPRESS;Database=HealthcareDB;Trusted_Connection=true;TrustServerCertificate=true;";
   ```
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
4. Build the API:
   ```bash
   dotnet build
   ```
5. Run the API:
   ```bash
   dotnet run
   ```
   The API will start at `https://localhost:7101`

### Step 3: Configure MVC Frontend

1. Navigate to `HealthcareMVC` folder
2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
3. Build the MVC:
   ```bash
   dotnet build
   ```
4. Run the MVC:
   ```bash
   dotnet run
   ```
   The MVC will start at `https://localhost:7100` (or another port)

## 📚 API Documentation

### Authentication Endpoints
- `POST /api/auth/register` - Create new user account
- `POST /api/auth/login` - Login user

### Doctor Endpoints
- `GET /api/doctors` - Get all doctors
- `GET /api/doctors/{doctorId}` - Get doctor by ID
- `GET /api/doctors/department/{departmentId}` - Get doctors by department

### Appointment Endpoints
- `POST /api/appointments/book` - Book new appointment
- `GET /api/appointments/patient/{patientId}` - Get patient's appointments
- `PATCH /api/appointments/{appointmentId}/cancel` - Cancel appointment

## 🎨 Design Features

### Color Palette
- **Primary**: Hot Pink (#ff1493)
- **Secondary**: Light Pink (#ffc0cb)
- **Success**: Green (#26de81)
- **Danger**: Red (#fc5c65)

### Typography
- **Headings**: Tangerine (Calligraphy font)
- **Body**: Quicksand (Clean, minimal font)

### UI Components
- Gradient backgrounds (pink/white themes)
- Smooth button animations
- Card-based layouts
- Rounded corners (20px)
- Shadow effects for depth
- Responsive grid system

## 🔐 Security Features

- Password hashing using SHA256
- Role-based access control
- Session management
- CORS enabled
- Input validation
- HTTPS encryption

## 📱 User Workflows

### Patient Flow
1. Register/Login
2. Browse doctors
3. Book appointment
4. View/cancel appointments

### Admin Flow
1. Login with admin credentials
2. Manage doctors
3. Manage appointments
4. View billing information

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0, Entity Framework Core
- **Frontend**: ASP.NET Core MVC, Razor Views, HTML/CSS/JavaScript
- **Database**: SQL Server
- **Authentication**: Custom authentication with hashing
- **API Pattern**: RESTful API

## 📝 Sample Data

The database includes:
- 3 Sample Doctors in different departments
- 4 Medical Departments
- 1 Admin user
- 1 Patient user

### Default Credentials
- **Admin**: admin@healthcare.com / (from schema)
- **Patient**: john.patient@healthcare.com / (from schema)

## 🔄 API Response Format

All API responses follow this format:
```json
{
  "success": true,
  "data": { /* response data */ },
  "message": "Operation successful"
}
```

## 🐛 Troubleshooting

### Database Connection Issues
- Verify SQL Server service is running
- Check connection string in `Program.cs`
- Ensure database name is `HealthcareDB`

### Port Conflicts
- API uses port `7101` by default
- MVC uses port `7100` by default
- Change in `launchSettings.json` if needed

### CORS Issues
- CORS is enabled for all origins in API
- Verify API URL in MVC controllers

## 📖 Additional Notes

- Password field in DB uses SHA256 hashing
- Session timeout is 30 minutes
- Appointment dates must be in the future
- Status values: Booked, Completed, Cancelled
- Payment status: Paid, Unpaid

---

**Created with 💕 for healthcare excellence**
