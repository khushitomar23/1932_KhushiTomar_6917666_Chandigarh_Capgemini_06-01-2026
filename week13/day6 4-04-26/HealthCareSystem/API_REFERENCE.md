# 📚 API Reference Documentation

## Base URL
```
https://localhost:7101/api
```

## Authentication Endpoints

### Register New User
**Endpoint:** `POST /auth/register`

**Request Body:**
```json
{
  "fullName": "John Doe",
  "email": "john.doe@example.com",
  "password": "securePassword123",
  "role": "Patient"
}
```

**Response (Success - 200):**
```json
{
  "success": true,
  "data": {
    "userId": 5,
    "fullName": "John Doe",
    "email": "john.doe@example.com",
    "role": "Patient"
  }
}
```

**Response (Error - 400):**
```json
{
  "success": false,
  "message": "Email already exists"
}
```

---

### Login User
**Endpoint:** `POST /auth/login`

**Request Body:**
```json
{
  "email": "john.doe@example.com",
  "password": "securePassword123"
}
```

**Response (Success - 200):**
```json
{
  "success": true,
  "message": "Login successful",
  "data": {
    "userId": 5,
    "fullName": "John Doe",
    "email": "john.doe@example.com",
    "role": "Patient"
  }
}
```

**Response (Error - 401):**
```json
{
  "success": false,
  "message": "Invalid email or password"
}
```

---

## Doctor Endpoints

### Get All Doctors
**Endpoint:** `GET /doctors`

**Response (Success - 200):**
```json
{
  "success": true,
  "data": [
    {
      "doctorId": 1,
      "fullName": "Dr. Sarah Johnson",
      "email": "sarah.johnson@healthcare.com",
      "departmentId": 1,
      "departmentName": "Cardiology",
      "specialization": "Cardiologist",
      "experienceYears": 12,
      "availability": "Mon-Fri 9AM-5PM"
    },
    {
      "doctorId": 2,
      "fullName": "Dr. Michael Chen",
      "email": "michael.chen@healthcare.com",
      "departmentId": 2,
      "departmentName": "Neurology",
      "specialization": "Neurologist",
      "experienceYears": 8,
      "availability": "Mon-Sat 10AM-6PM"
    }
  ]
}
```

---

### Get Doctor by ID
**Endpoint:** `GET /doctors/{doctorId}`

**Parameters:**
- `doctorId` (int, required): The ID of the doctor

**Example:** `GET /doctors/1`

**Response (Success - 200):**
```json
{
  "success": true,
  "data": {
    "doctorId": 1,
    "fullName": "Dr. Sarah Johnson",
    "email": "sarah.johnson@healthcare.com",
    "departmentId": 1,
    "departmentName": "Cardiology",
    "specialization": "Cardiologist",
    "experienceYears": 12,
    "availability": "Mon-Fri 9AM-5PM"
  }
}
```

---

### Get Doctors by Department
**Endpoint:** `GET /doctors/department/{departmentId}`

**Parameters:**
- `departmentId` (int, required): The ID of the department

**Example:** `GET /doctors/department/1`

**Response (Success - 200):**
```json
{
  "success": true,
  "data": [
    {
      "doctorId": 1,
      "fullName": "Dr. Sarah Johnson",
      "email": "sarah.johnson@healthcare.com",
      "departmentId": 1,
      "departmentName": "Cardiology",
      "specialization": "Cardiologist",
      "experienceYears": 12,
      "availability": "Mon-Fri 9AM-5PM"
    }
  ]
}
```

---

## Appointment Endpoints

### Book Appointment
**Endpoint:** `POST /appointments/book`

**Query Parameters:**
- `patientId` (int, required): The ID of the patient

**Request Body:**
```json
{
  "doctorId": 1,
  "appointmentDate": "2025-04-15T10:00:00"
}
```

**Response (Success - 200):**
```json
{
  "success": true,
  "data": {
    "appointmentId": 5,
    "patientId": 5,
    "doctorId": 1,
    "doctorName": "Dr. Sarah Johnson",
    "appointmentDate": "2025-04-15T10:00:00",
    "status": "Booked"
  }
}
```

**Response (Error - 400):**
```json
{
  "success": false,
  "message": "Error booking appointment"
}
```

---

### Get Patient Appointments
**Endpoint:** `GET /appointments/patient/{patientId}`

**Parameters:**
- `patientId` (int, required): The ID of the patient

**Example:** `GET /appointments/patient/5`

**Response (Success - 200):**
```json
{
  "success": true,
  "data": [
    {
      "appointmentId": 5,
      "patientId": 5,
      "doctorId": 1,
      "doctorName": "Dr. Sarah Johnson",
      "appointmentDate": "2025-04-15T10:00:00",
      "status": "Booked"
    },
    {
      "appointmentId": 6,
      "patientId": 5,
      "doctorId": 2,
      "doctorName": "Dr. Michael Chen",
      "appointmentDate": "2025-04-20T14:30:00",
      "status": "Completed"
    }
  ]
}
```

---

### Cancel Appointment
**Endpoint:** `PATCH /appointments/{appointmentId}/cancel`

**Parameters:**
- `appointmentId` (int, required): The ID of the appointment

**Example:** `PATCH /appointments/5/cancel`

**Response (Success - 200):**
```json
{
  "success": true,
  "data": {
    "appointmentId": 5,
    "patientId": 5,
    "doctorId": 1,
    "doctorName": "Dr. Sarah Johnson",
    "appointmentDate": "2025-04-15T10:00:00",
    "status": "Cancelled"
  }
}
```

---

## Status Codes

| Code | Meaning |
|------|---------|
| 200 | Success |
| 400 | Bad Request (validation error) |
| 401 | Unauthorized (invalid login) |
| 404 | Not Found |
| 500 | Internal Server Error |

## Available Departments

| ID | Name | Description |
|----|------|-------------|
| 1 | Cardiology | Heart and cardiovascular diseases |
| 2 | Neurology | Brain and nervous system disorders |
| 3 | Orthopedics | Bone and joint disorders |
| 4 | Dermatology | Skin disorders |

## Appointment Status Values
- `Booked` - Appointment is scheduled
- `Completed` - Appointment has been completed
- `Cancelled` - Appointment has been cancelled

---

**Last Updated:** 2025-04-04
**Version:** 1.0
