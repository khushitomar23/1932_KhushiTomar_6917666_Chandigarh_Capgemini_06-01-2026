-- Healthcare Appointment System Database
-- SQL Server Setup Script

-- Create Database
CREATE DATABASE HealthcareDB;
GO

USE HealthcareDB;
GO

-- Create Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin','Doctor','Patient')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create Departments Table
CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

-- Create Doctors Table
CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT UNIQUE,
    DepartmentId INT,
    Specialization NVARCHAR(100),
    ExperienceYears INT,
    Availability NVARCHAR(100),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);

-- Create Appointments Table
CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT,
    DoctorId INT,
    AppointmentDate DATETIME,
    Status NVARCHAR(20) CHECK (Status IN ('Booked','Completed','Cancelled')),
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- Create Prescriptions Table
CREATE TABLE Prescriptions (
    PrescriptionId INT PRIMARY KEY IDENTITY(1,1),
    AppointmentId INT UNIQUE,
    Diagnosis NVARCHAR(255),
    Medicines NVARCHAR(MAX),
    Notes NVARCHAR(255),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

-- Create Bills Table
CREATE TABLE Bills (
    BillId INT PRIMARY KEY IDENTITY(1,1),
    AppointmentId INT,
    ConsultationFee DECIMAL(10,2),
    MedicineCharges DECIMAL(10,2),
    TotalAmount AS (ConsultationFee + MedicineCharges),
    PaymentStatus NVARCHAR(20) CHECK (PaymentStatus IN ('Paid','Unpaid')),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

-- Insert Sample Data
INSERT INTO Departments (DepartmentName, Description) VALUES
('Cardiology', 'Heart and cardiovascular diseases'),
('Neurology', 'Brain and nervous system disorders'),
('Orthopedics', 'Bone and joint disorders'),
('Dermatology', 'Skin disorders');

GO

-- Insert Sample Users
INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES
('Dr. Sarah Johnson', 'sarah.johnson@healthcare.com', '$2a$11$example_hash_1', 'Doctor'),
('Dr. Michael Chen', 'michael.chen@healthcare.com', '$2a$11$example_hash_2', 'Doctor'),
('Dr. Emily Rodriguez', 'emily.rodriguez@healthcare.com', '$2a$11$example_hash_3', 'Doctor'),
('Admin User', 'admin@healthcare.com', '$2a$11$example_hash_4', 'Admin'),
('John Patient', 'john.patient@healthcare.com', '$2a$11$example_hash_5', 'Patient');

GO

-- Insert Sample Doctors
INSERT INTO Doctors (UserId, DepartmentId, Specialization, ExperienceYears, Availability) VALUES
(1, 1, 'Cardiologist', 12, 'Mon-Fri 9AM-5PM'),
(2, 2, 'Neurologist', 8, 'Mon-Sat 10AM-6PM'),
(3, 3, 'Orthopedist', 10, 'Tue-Sat 2PM-8PM');

GO
