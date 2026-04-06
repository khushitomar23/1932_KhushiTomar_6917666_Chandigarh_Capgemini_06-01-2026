using HealthcareAPI;
using HealthcareAPI.Repositories;
using HealthcareAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Get connection string for SQL Server
var connectionString = "Server=KHUSHI23\\SQLEXPRESS;Database=HealthcareDB;Trusted_Connection=true;TrustServerCertificate=true;";

// Add DbContext
builder.Services.AddDbContext<HealthcareDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI with JWT Bearer token support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Define the Bearer token security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    // Add security requirement globally for all endpoints
    var securityScheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new List<string>() }
    });

    // Add API info
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Healthcare Appointment System API",
        Version = "v1",
        Description = "API for managing healthcare appointments with JWT Bearer token authentication",
        Contact = new OpenApiContact
        {
            Name = "Healthcare Support",
            Email = "support@healthcare.com"
        }
    });
});

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<HealthcareDbContext>();
    
    // Run database seed
    SeedDatabase(context);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();

// Seed database method
static void SeedDatabase(HealthcareDbContext context)
{
    try
    {
        // Check if departments already exist
        if (context.Departments.Any())
            return;

        // Create departments
        var departments = new[]
        {
            new { DepartmentId = 1, DepartmentName = "General Medicine", Description = "General medical care and consultation" },
            new { DepartmentId = 2, DepartmentName = "Cardiology", Description = "Heart and cardiovascular system care" },
            new { DepartmentId = 3, DepartmentName = "Orthopedics", Description = "Bone, joint and muscle care" },
            new { DepartmentId = 4, DepartmentName = "Neurology", Description = "Nervous system and brain care" },
            new { DepartmentId = 5, DepartmentName = "Dermatology", Description = "Skin care and treatment" }
        };

        foreach (var dept in departments)
        {
            context.Departments.Add(new HealthcareShared.Models.Department
            {
                DepartmentName = dept.DepartmentName,
                Description = dept.Description
            });
        }

        context.SaveChanges();

        // Create sample users (doctors)
        var doctors = new[]
        {
            new { FullName = "Dr. Rajesh Kumar", Email = "rajesh.kumar@healthcare.com", Password = "Dr@1234Kumar", Role = "Doctor", DeptId = 1 },
            new { FullName = "Dr. Priya Singh", Email = "priya.singh@healthcare.com", Password = "Dr@1234Priya", Role = "Doctor", DeptId = 2 },
            new { FullName = "Dr. Amit Patel", Email = "amit.patel@healthcare.com", Password = "Dr@1234Amit", Role = "Doctor", DeptId = 3 },
            new { FullName = "Dr. Neha Sharma", Email = "neha.sharma@healthcare.com", Password = "Dr@1234Neha", Role = "Doctor", DeptId = 4 },
            new { FullName = "Dr. Vijay Desai", Email = "vijay.desai@healthcare.com", Password = "Dr@1234Vijay", Role = "Doctor", DeptId = 5 }
        };

        foreach (var doc in doctors)
        {
            var user = new HealthcareShared.Models.User
            {
                FullName = doc.FullName,
                Email = doc.Email,
                PasswordHash = HashPassword(doc.Password),
                Role = doc.Role,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(user);
            context.SaveChanges();

            var doctor = new HealthcareShared.Models.Doctor
            {
                UserId = user.UserId,
                DepartmentId = doc.DeptId,
                Specialization = "Specialist",
                ExperienceYears = 10,
                Availability = "Monday to Friday, 9AM-5PM"
            };

            context.Doctors.Add(doctor);
        }

        context.SaveChanges();
    }
    catch (Exception ex)
    {
        // Log exception - in production you'd use proper logging
        Console.WriteLine($"Error seeding database: {ex.Message}");
    }
}

static string HashPassword(string password)
{
    using (var sha256 = System.Security.Cryptography.SHA256.Create())
    {
        var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}
