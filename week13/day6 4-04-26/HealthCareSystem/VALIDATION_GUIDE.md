# Healthcare System - Validation Implementation Guide

## Overview
This document describes the comprehensive validation system implemented across the Healthcare Appointment System, including data validation in API and MVC, server-side validation, and custom validation logic.

---

## 1. Model Validation (HealthcareShared.Models)

### 1.1 User Model Validation
```csharp
public class User
{
    [Required] Full name is required
    [StringLength(100, MinimumLength = 2)] Full name 2-100 chars
    
    [Required] Email is required
    [EmailAddress] Valid email format
    [StringLength(100)] Email max 100 chars
    
    [Required] Password is required
    [StringLength(255, MinimumLength = 6)] 6-255 chars
    
    [Required] Role is required
    [RegularExpression(@"^(Admin|Doctor|Patient)$")] Valid role
}
```

**Validation Rules:**
- Full Name: Required, 2-100 characters
- Email: Required, valid email format, max 100 characters
- Password: Required, min 6 characters
- Role: Required, must be "Admin", "Doctor", or "Patient"

---

### 1.2 Doctor Model Validation
```csharp
public class Doctor
{
    [Required] [Range(1, int.MaxValue)] User ID required & valid
    [Required] [Range(1, int.MaxValue)] Department ID required & valid
    
    [Required] Specialization is required
    [StringLength(50, MinimumLength = 3)] 3-50 characters
    
    [Required] Experience years required
    [Range(0, 60)] 0-60 years
    
    [Required] Availability required
    [StringLength(100, MinimumLength = 3)] 3-100 characters
}
```

**Validation Rules:**
- User ID: Required, must be valid (> 0)
- Department ID: Required, must be valid (> 0)
- Specialization: Required, 3-50 characters
- Experience Years: Required, between 0-60 years
- Availability: Required, 3-100 characters

---

### 1.3 Appointment Model Validation
```csharp
public class Appointment
{
    [Required] [Range(1, int.MaxValue)] Patient ID required & valid
    [Required] [Range(1, int.MaxValue)] Doctor ID required & valid
    
    [Required] [CustomValidation] Appointment date required
    // Date must be in the future (ValidateFutureDate method)
    
    [Required] [RegularExpression(@"^(Booked|Completed|Cancelled)$")]
    // Status: Booked, Completed, or Cancelled
}
```

**Validation Rules:**
- Patient ID: Required, must be valid
- Doctor ID: Required, must be valid
- Appointment Date: Required, must be future date
- Status: Required, must be "Booked", "Completed", or "Cancelled"

---

### 1.4 Department Model Validation
```csharp
public class Department
{
    [Required] Department name required
    [StringLength(50, MinimumLength = 3)] 3-50 characters
    
    [StringLength(500)] Description max 500 chars
}
```

---

### 1.5 Prescription Model Validation
```csharp
public class Prescription
{
    [Required] [Range(1, int.MaxValue)] Appointment ID required & valid
    
    [Required] Diagnosis required
    [StringLength(500, MinimumLength = 5)] 5-500 characters
    
    [Required] Medicines required
    [StringLength(1000, MinimumLength = 3)] 3-1000 characters
    
    [StringLength(1000)] Notes max 1000 chars
}
```

---

### 1.6 Bill Model Validation
```csharp
public class Bill
{
    [Required] [Range(1, int.MaxValue)] Appointment ID required
    
    [Required] [Range(0, 10000)] Consultation fee (0-10000)
    [DataType(DataType.Currency)]
    
    [Required] [Range(0, 10000)] Medicine charges (0-10000)
    [DataType(DataType.Currency)]
    
    [Required] [Range(0, 20000)] Total amount (0-20000)
    [DataType(DataType.Currency)]
    
    [Required] [RegularExpression(@"^(Paid|Unpaid)$")]
    // Payment Status: Paid or Unpaid
}
```

---

## 2. DTO Validation (HealthcareAPI.DTOs)

### 2.1 LoginDto Validation
```csharp
public class LoginDto
{
    [Required] [EmailAddress] Email required, valid format
    [Required] [StringLength(255, MinimumLength = 6)] Password 6-255 chars
}
```

---

### 2.2 RegisterDto Validation
```csharp
public class RegisterDto
{
    [Required] [StringLength(100, MinimumLength = 2)]
    Full name 2-100 characters
    
    [Required] [EmailAddress] [StringLength(100)]
    Email required, valid format
    
    [Required] [StringLength(255, MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$")]
    Password must contain:
    - At least one lowercase letter
    - At least one uppercase letter
    - At least one digit
    - Minimum 6 characters
    
    [RegularExpression(@"^(Admin|Doctor|Patient)$")]
    Role must be Admin, Doctor, or Patient
}
```

---

### 2.3 CreateAppointmentDto Validation
```csharp
public class CreateAppointmentDto
{
    [Required] [Range(1, int.MaxValue)]
    Doctor ID required and valid
    
    [Required] [DataType(DataType.DateTime)]
    [CustomValidation(typeof(CreateAppointmentDto), nameof(ValidateFutureDate))]
    Appointment date required, must be in future
}
```

---

## 3. ViewModel Validation (HealthcareMVC.Models)

### 3.1 LoginViewModel Validation
```csharp
public class LoginViewModel
{
    [Required] [EmailAddress]
    Email required, valid format
    
    [Required] [StringLength(255, MinimumLength = 6)]
    Password required, 6-255 characters
}
```

---

### 3.2 RegisterViewModel Validation
```csharp
public class RegisterViewModel
{
    [Required] [StringLength(100, MinimumLength = 2)]
    Full name 2-100 characters
    
    [Required] [EmailAddress] [StringLength(100)]
    Email required, valid format
    
    [Required] [StringLength(255, MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$")]
    Password strength requirements (lowercase, uppercase, digit, 6+ chars)
    
    [Required] [Compare("Password")]
    Confirm password must match Password field
}
```

---

### 3.3 CreateAppointmentViewModel Validation
```csharp
public class CreateAppointmentViewModel
{
    [Required] [Range(1, int.MaxValue)]
    Doctor ID required and valid
    
    [Required] [DataType(DataType.DateTime)]
    [CustomValidation(typeof(CreateAppointmentViewModel), nameof(ValidateFutureDate))]
    Appointment date required, must be in future
}
```

---

## 4. API Service Validation

### 4.1 AuthService Validation
**Enhanced validation includes:**

1. **RegisterAsync Method:**
   - Validates RegisterDto is not null
   - Checks full name length (2-100 chars)
   - Validates email format using MailAddress class
   - Validates email doesn't already exist in database
   - Validates password strength:
     - Minimum 6 characters
     - Contains at least one lowercase letter
     - Contains at least one uppercase letter
     - Contains at least one digit
   - Normalizes input (trim, lowercase email)

2. **LoginAsync Method:**
   - Validates email and password are not empty
   - Normalizes email (lowercase)
   - Case-insensitive email matching
   - Constant-time password comparison (security best practice)

---

### 4.2 AppointmentService Validation
**Enhanced validation includes:**

1. **BookAppointmentAsync Method:**
   - Validates CreateAppointmentDto is not null
   - Validates patient ID is valid (> 0)
   - Validates doctor exists in database
   - Validates appointment date is in the future
   - Validates date is not beyond 6 months from now
   - Checks for duplicate appointments (same doctor, same date)
   - Validates status = "Booked"

2. **CancelAppointmentAsync Method:**
   - Validates appointment ID is valid (> 0)
   - Validates appointment exists
   - Validates appointment hasn't already been cancelled
   - Validates appointment isn't completed
   - Prevents cancellation of completed appointments

3. **GetPatientAppointmentsAsync Method:**
   - Validates patient ID is valid (> 0)

---

## 5. API Controller Validation (HealthcareAPI.Controllers)

### 5.1 AuthController Validation
**HTTP Endpoints with Validation:**

```
POST /api/auth/register
POST /api/auth/login
```

**Validation Steps:**
1. Checks ModelState validity
2. Returns detailed validation error messages
3. Catches InvalidOperationException for business logic errors
4. Returns 400 (Bad Request) for validation failures
5. Returns 500 for unexpected errors

**Error Response Format:**
```json
{
    "success": false,
    "message": "Validation failed",
    "errors": ["Email already exists", "Password is weak"]
}
```

---

### 5.2 AppointmentsController Validation
**HTTP Endpoints with Validation:**

```
POST /api/appointments/book
GET /api/appointments/patient/{patientId}
PATCH /api/appointments/{appointmentId}/cancel
```

**Validation Steps:**
1. Checks ModelState for CreateAppointmentDto
2. Validates patient ID from query parameter
3. Returns validation errors from services
4. Catches InvalidOperationException for business logic
5. Returns proper HTTP status codes

---

## 6. MVC Controller Validation (HealthcareMVC.Controllers)

### 6.1 AuthController in MVC
**Validation Steps:**

1. **Login Post Method:**
   - Checks ModelState.IsValid before API call
   - Parses error response from API
   - Displays user-friendly error messages
   - Handles network errors gracefully
   - Extracts error messages from API response

2. **Register Post Method:**
   - Validates ModelState (includes [Compare] for password match)
   - Sends to API for server-side validation
   - Parses validation errors from API response
   - Displays multiple validation errors
   - Redirects with success message on success

---

### 6.2 AppointmentsController in MVC
**Validation Steps:**

1. **Book Post Method:**
   - Checks user authentication (redirects to login if needed)
   - Validates ModelState before API call
   - Additional server-side future date validation
   - Validates doctor ID is valid (> 0)
   - Parses error response from API
   - Uses TempData for success/error messages
   - Redirects to MyAppointments on success

2. **MyAppointments Get Method:**
   - Validates user authentication
   - Handles connection errors
   - Displays user-friendly error messages
   - Returns empty list on error

3. **Cancel Post Method:**
   - Validates appointment ID (> 0)
   - Catches service-level errors
   - Parses API error response
   - Uses TempData for messaging
   - Handles network errors

---

## 7. Data Layer (HealthcareAPI.Data)

### HealthcareDbContext
- Validates entity relationships before save
- Enforces foreign key constraints
- Seed data follows validation rules
- Database validation through EF Core

---

## 8. Client-Side Validation (MVC Views)

### JavaScript Validation (wwwroot/js/script.js)
**Real-time Validation:**
- Email format validation
- Password strength indicators
- Password confirmation matching
- Date/time future enforcement (min date calculation)
- Form field required checks
- String length validation
- Real-time feedback (red/green borders)

**Features:**
- Instant validation feedback as user types
- Password strength indicator (weak/medium/strong)
- Password confirmation matching before submission
- Date picker prevents past dates
- Loading states during form submission
- Appointment cancellation confirmation
- Keyboard shortcuts
- Debug utilities

---

## 9. Validation Error Flow

### From Client to Server:
```
User Input
    ↓
Client-Side JS Validation (Real-time Feedback)
    ↓
MVC ViewModel Validation (ModelState.IsValid)
    ↓
API Call (if valid)
    ↓
API DTO Validation (ModelState.IsValid)
    ↓
Service Business Logic Validation
    ↓
Database Constraints
```

### Error Response to User:
```
API Error ← Service throws InvalidOperationException
    ↓
API Controller catches & returns 400/401
    ↓
MVC Controller parses error JSON
    ↓
ModelState.AddModelError() 
    ↓
View displays validation errors
    ↓
User sees friendly error message
```

---

## 10. ValidationResult Custom Validators

### Future Date Validation
```csharp
public static ValidationResult ValidateFutureDate(
    DateTime appointmentDate, 
    ValidationContext context)
{
    if (appointmentDate <= DateTime.Now)
        return new ValidationResult("Appointment date must be in the future");
    return ValidationResult.Success;
}
```

**Used in:**
- Appointment model
- CreateAppointmentDto
- CreateAppointmentViewModel

---

## 11. Exception Handling Strategy

### API Controllers:
- **InvalidOperationException**: Business logic validation errors → 400 Bad Request
- **ArgumentNullException**: Null input validation → 400 Bad Request  
- **General Exception**: Unexpected errors → 500 Internal Server Error

### MVC Controllers:
- **HttpRequestException**: Network errors → User-friendly message
- **JsonException**: Parsing errors → Fallback error message
- All exceptions logged in ViewBag.Error or TempData

---

## 12. Security Considerations

### Password Security:
- ✅ Minimum 6 characters required
- ✅ Must contain lowercase letter
- ✅ Must contain uppercase letter
- ✅ Must contain digit
- ✅ SHA256 hashing on server
- ✅ Constant-time password comparison

### Email Security:
- ✅ Format validation
- ✅ Duplicate email check
- ✅ Normalization (lowercase)

### Data Integrity:
- ✅ Foreign key constraints
- ✅ ID range validation
- ✅ Status enum validation
- ✅ Date validation (no past appointments)

---

## 13. Testing Validation

### Test Cases:

**Authentication:**
- [ ] Register with invalid email → Error message
- [ ] Register with weak password → Error message
- [ ] Register with duplicate email → Error message
- [ ] Login with wrong password → Error message
- [ ] Login with nonexistent email → Error message

**Appointments:**
- [ ] Book with date in past → Error message
- [ ] Book with invalid doctor ID → Error message
- [ ] Book duplicate appointment → Error message
- [ ] Cancel non-existent appointment → Error message
- [ ] Cancel completed appointment → Error message

**Data Validation:**
- [ ] Submit empty form → Required field errors
- [ ] Submit invalid email → Email format error
- [ ] Submit short password → Length error
- [ ] Submit mismatched passwords → Compare error

---

## 14. Summary

### Validation Layers:
1. **Client-Side**: JavaScript real-time validation (UX)
2. **MVC**: ViewModel validation + ModelState checks (Form validation)
3. **API**: DTO validation + ModelState checks (API contract)
4. **Service**: Business logic validation (Rules enforcement)
5. **Database**: Constraints & relationships (Data integrity)

### Validation Coverage:
- ✅ 6 Models with complete validation attributes
- ✅ 3 DTOs with comprehensive validation
- ✅ 2 ViewModels with validation
- ✅ 2 Services with business logic validation
- ✅ 2 API Controllers with ModelState checks
- ✅ 2 MVC Controllers with ModelState checks
- ✅ JavaScript client-side validation
- ✅ Custom validation methods for complex rules
- ✅ Clean error handling and messaging

---

## 15. Quick Reference

### Run & Test:

1. **Build projects:**
   ```bash
   cd HealthcareAPI
   dotnet build
   dotnet run
   ```

2. **Run migrations:**
   ```bash
   dotnet ef database update
   ```

3. **Start MVC:**
   ```bash
   cd HealthcareMVC
   dotnet run
   ```

4. **Test validation:**
   - Navigate to http://localhost:5000/auth/register
   - Try invalid inputs
   - Check console for validation messages
   - Submit and see API validation responses

---

**Last Updated:** April 4, 2026
**Status:** Complete ✅
