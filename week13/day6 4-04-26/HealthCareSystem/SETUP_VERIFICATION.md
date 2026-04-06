# 🔍 Setup Verification Checklist

Use this checklist to verify your Healthcare Appointment System is properly set up and ready to run.

## ✅ Pre-Setup Requirements

- [ ] .NET 8.0 SDK is installed
  - Check: Open Terminal/CMD and run `dotnet --version`
  - Should show: `8.0.x`

- [ ] SQL Server is installed and running
  - Check: Open SSMS
  - Should connect to: `KHUSHI23\SQLEXPRESS`

- [ ] Visual Studio Code or Visual Studio 2022 is installed

- [ ] You have administrator access to SQL Server

---

## 📦 Database Setup Verification

### Step 1: Create Database
- [ ] Opened `Database/HealthcareDB_Schema.sql`
- [ ] Executed the SQL script in SSMS
- [ ] No errors appeared during execution

### Step 2: Verify Database Created
Open SSMS and:
- [ ] Connect to `KHUSHI23\SQLEXPRESS`
- [ ] In Object Explorer, expand **Databases**
- [ ] Look for **HealthcareDB** (should be visible)
- [ ] Expand HealthcareDB → Tables
- [ ] Verify these tables exist:
  - [ ] dbo.Users
  - [ ] dbo.Departments
  - [ ] dbo.Doctors
  - [ ] dbo.Appointments
  - [ ] dbo.Prescriptions
  - [ ] dbo.Bills

### Step 3: Verify Sample Data
In SSMS, run these queries:

**Check Departments:**
```sql
SELECT * FROM HealthcareDB.dbo.Departments;
```
- [ ] Should return 4 departments (Cardiology, Neurology, Orthopedics, Dermatology)

**Check Doctors:**
```sql
SELECT * FROM HealthcareDB.dbo.Doctors;
```
- [ ] Should return 3 doctors

**Check Users:**
```sql
SELECT * FROM HealthcareDB.dbo.Users;
```
- [ ] Should return 5 users (3 doctors, 1 admin, 1 patient)

---

## 🔌 API Setup Verification

### Step 1: Project Structure
- [ ] HealthcareAPI folder exists at specified location
- [ ] These folders are present in HealthcareAPI:
  - [ ] Models/
  - [ ] Controllers/
  - [ ] Services/
  - [ ] Repositories/
  - [ ] Data/
  - [ ] DTOs/

### Step 2: Required Files
Verify these files exist in HealthcareAPI:
- [ ] Program.cs
- [ ] appsettings.json
- [ ] HealthcareAPI.csproj
- [ ] Models/User.cs, Doctor.cs, etc. (6 model files)
- [ ] Controllers/AuthController.cs, DoctorsController.cs, AppointmentsController.cs
- [ ] Services/AuthService.cs, DoctorService.cs, AppointmentService.cs
- [ ] Repositories/RepositoryImplementations.cs, RepositoryInterfaces.cs

### Step 3: Build API
Open Terminal/CMD in HealthcareAPI folder:
```bash
cd HealthcareAPI
dotnet restore
dotnet build
```
- [ ] Command completes without errors
- [ ] No "error" messages in output

### Step 4: Run API
```bash
dotnet run
```
- [ ] Application starts
- [ ] Output shows: `Listening on https://localhost:7101`
- [ ] Keep this terminal running
- [ ] Open browser to `https://localhost:7101/swagger`
- [ ] [ ] Swagger UI loads (you should see API documentation)

---

## 🎨 MVC Frontend Verification

### Step 1: Project Structure
- [ ] HealthcareMVC folder exists
- [ ] These folders are present:
  - [ ] Controllers/
  - [ ] Models/
  - [ ] Views/
  - [ ] wwwroot/css/
  - [ ] wwwroot/js/

### Step 2: Required Files
Verify these files exist in HealthcareMVC:
- [ ] Program.cs
- [ ] appsettings.json
- [ ] HealthcareMVC.csproj
- [ ] Controllers/HomeController.cs, AuthController.cs, DoctorsController.cs, AppointmentsController.cs
- [ ] Views/_Layout.cshtml, Home/Index.cshtml, Auth/Login.cshtml, Auth/Register.cshtml
- [ ] Views/Doctors/Index.cshtml
- [ ] Views/Appointments/Book.cshtml, MyAppointments.cshtml
- [ ] wwwroot/css/style.css
- [ ] wwwroot/js/script.js

### Step 3: Build MVC
Open a NEW Terminal/CMD in HealthcareMVC folder:
```bash
cd HealthcareMVC
dotnet restore
dotnet build
```
- [ ] Command completes without errors
- [ ] No "error" messages in output

### Step 4: Run MVC
```bash
dotnet run
```
- [ ] Application starts
- [ ] Output shows a localhost URL (e.g., `https://localhost:7100`)
- [ ] Keep this terminal running

### Step 5: Test MVC in Browser
- [ ] Open browser to the MVC URL from terminal output
- [ ] [ ] Homepage loads successfully
- [ ] [ ] See "Welcome to Your Healthcare Portal" title
- [ ] [ ] See navigation menu at top
- [ ] [ ] See "Login" and "Register" buttons

---

## 🧪 Functional Testing

### Test 1: User Registration
1. In MVC browser, click "Register"
2. Fill in form:
   - Full Name: John Test
   - Email: johntest@example.com
   - Password: Password123
   - Confirm: Password123
3. Click "Register"
- [ ] Redirects to Login page
- [ ] See "Register successful" or redirected to login

### Test 2: User Login
1. Click "Login"
2. Enter credentials:
   - Email: johntest@example.com
   - Password: Password123
3. Click "Login"
- [ ] Redirects to Home page
- [ ] See "Logout" button in navigation (you're logged in!)

### Test 3: View Doctors
1. Click "Browse Doctors" or navigate to `/doctors`
- [ ] See list of doctors
- [ ] See doctor cards with:
  - [ ] Doctor name
  - [ ] Department
  - [ ] Specialization
  - [ ] Experience years
  - [ ] Availability
  - [ ] "Book Appointment" button

### Test 4: Book Appointment
1. Click "Book Appointment" for any doctor
2. Select date and time in the future
3. Click "Confirm Booking"
- [ ] Redirects to "My Appointments"
- [ ] New appointment appears in the list

### Test 5: View Appointments
1. Click "My Appointments" in navigation
- [ ] See list of booked appointments
- [ ] Each appointment shows:
  - [ ] Doctor name
  - [ ] Date and time
  - [ ] Status ("Booked")
  - [ ] "Cancel" button

### Test 6: Cancel Appointment
1. Click "Cancel" on any appointment
- [ ] Confirm dialog appears
- [ ] Click "OK" to confirm
- [ ] Appointment status changes to "Cancelled"

### Test 7: Logout
1. Click "Logout" button
- [ ] Redirects to home page
- [ ] "Login" and "Register" buttons appear again
- [ ] Session cleared

---

## 🎨 UI/UX Verification

### Visual Design
- [ ] Pink color scheme is visible
- [ ] Calligraphy fonts appear on headings
- [ ] Gradient backgrounds render correctly
- [ ] Buttons have hover effects (smooth animations)
- [ ] Cards have shadow effects
- [ ] Layout is responsive (resize browser to check)

### Mobile Responsiveness
Resize browser to mobile width (375px):
- [ ] Navigation menu is accessible
- [ ] Forms are readable and usable
- [ ] Buttons are clickable
- [ ] Text is not cut off
- [ ] Layout stacks properly

### Emoji Icons
- [ ] 💕 appears in navbar and header
- [ ] 🌸 appears in register page
- [ ] 👨‍⚕️ appears on doctors page
- [ ] 📅 appears on appointment pages
- [ ] Other emojis visible throughout UI

---

## 🔗 API and MVC Integration

### Test 1: API → MVC Communication
- [ ] MVC successfully fetches doctors from API
- [ ] Doctor list displays actual data
- [ ] No CORS errors in browser console

### Test 2: Authentication Flow
- [ ] Register in MVC calls `/api/auth/register`
- [ ] Login in MVC calls `/api/auth/login`
- [ ] User data is returned correctly

### Test 3: Appointment Management
- [ ] Book appointment calls `/api/appointments/book`
- [ ] View appointments calls `/api/appointments/patient/{id}`
- [ ] Cancel appointment calls `/api/appointments/{id}/cancel`

---

## 🐛 Debugging Tools

### Check Browser Console
1. Press F12 in browser
2. Click "Console" tab
- [ ] No JavaScript errors (red text)
- [ ] No CORS errors

### Check Terminal Output
API Terminal should show:
- [ ] Each API call logged
- [ ] No exceptions or errors
- [ ] Server still running

MVC Terminal should show:
- [ ] Requests being processed
- [ ] No errors in output

---

## ✅ Final Verification

At this point, check:
- [ ] Database has all tables and sample data
- [ ] API runs without errors on port 7101
- [ ] MVC runs without errors on port 7100
- [ ] MVC home page loads
- [ ] Can register new user
- [ ] Can login with credentials
- [ ] Can view doctors list
- [ ] Can book appointment
- [ ] Can view appointments
- [ ] Can cancel appointment
- [ ] Can logout
- [ ] UI has pink theme and calligraphy fonts
- [ ] Mobile responsive works
- [ ] No console errors

---

## 🆘 If Something Fails

### API Won't Start
- [ ] Check if port 7101 is available
- [ ] Verify .NET 8.0 SDK is installed
- [ ] Check connection string in `Program.cs`
- [ ] Ensure HealthcareDB exists in SQL Server

### MVC Won't Start
- [ ] Check if API is running first
- [ ] Verify .NET 8.0 SDK is installed
- [ ] Check port not in use

### Database Errors
- [ ] Verify SQL Server is running
- [ ] Check connection: `Server=KHUSHI23\SQLEXPRESS`
- [ ] Rerun the SQL schema script
- [ ] Check for syntax errors in SQL

### UI Looks Wrong
- [ ] Clear browser cache (Ctrl+Shift+Delete)
- [ ] Check `style.css` was loaded (F12 → Network tab)
- [ ] Verify font links in `_Layout.cshtml`

---

## 📞 Quick Links

- **Database Script**: `Database/HealthcareDB_Schema.sql`
- **API Project**: `HealthcareAPI/Program.cs`
- **MVC Project**: `HealthcareMVC/Program.cs`
- **API Documentation**: `API_REFERENCE.md`
- **Setup Guide**: `QUICKSTART.md`

---

**Status**: ✅ Ready when all checkboxes are marked!

Created with 💕 for your success!
