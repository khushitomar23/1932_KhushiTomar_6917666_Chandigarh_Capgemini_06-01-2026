create database employeeDb;
use employeeDb;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
[AddressID][int] PRIMARY KEY identity(1,1),
[Street][varchar](255)NULL,
[City][varchar](100) NULL,
State varchar(100) null,
PostalCode varchar(20) null
);
drop table Address;

create table Employee(
EmployeeId int PRIMARY KEY identity(1,1),
FirstName varchar(100) null,
LastName varchar(100)null,
Email varchar(100) null,
AddressID int null,
foreign key (AddressID) references Address(AddressID) 
);
drop table Employee;

Insert into Address Values('1234 Elm Street','SpringField','Illinois','62704');
Insert into Address Values('5678 Oak Street','Decatur','Alabama','35601');
Insert into Address Values('123 Patia','BBSR','India','755019');
Insert into Address Values('123 patia','BBSR','India','755019');
Select * from Address;

Insert into Employee Values('John','Doe','johndoe@example.com',1);
Insert into Employee Values('Jane','Doe','janedoe@example.com',2);
Insert into Employee Values('Ramesh','Sharma','ramesh@example.com',3);
Insert into Employee Values('Ramesh','Sharma','ramesh@example.com',4);
select * from Employee;

--Procedure1
CREATE PROCEDURE [dbo].[CreateEmployeeWithAddress]
@FirstName VARCHAR(100),
@LastName VARCHAR(100),
@Email VARCHAR(100),
@Street VARCHAR(255),
@City VARCHAR(100),
@State VARCHAR(100),
@PostalCode VARCHAR(20)
AS
BEGIN
DECLARE @AddressID INT;

INSERT INTO Address (Street, City, State, PostalCode)
VALUES (@Street, @City, @State, @PostalCode);
SET @AddressID= SCOPE_IDENTITY();

INSERT INTO Employee (FirstName, LastName, Email, AddressID)
VALUES (@FirstName, @LastName, @Email, @AddressID);
END;

--Procedure2
CREATE PROCEDURE [dbo].[DeleteEmployee]
@EmployeeId INT
AS
BEGIN
DECLARE @AddressID INT;
--Start transaction
BEGIN TRANSACTION;
--Get the AddressID for rollback purposes
SELECT @AddressID = AddressID FROM Employee WHERE EmployeeId = @EmployeeId;
--Delete the Employee record
DELETE FROM Employee WHERE EmployeeId= @EmployeeId;
--Delete the Address record
DELETE FROM Address WHERE AddressID = @AddressID;
--Commit transaction
COMMIT TRANSACTION
END;


--Procedure3
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
SELECT e.EmployeeId, e.FirstName, e.LastName, e.Email, a.Street,
a.City, a.State, a.PostalCode
FROM Employee e
INNER JOIN Address a ON e.AddressID =a.AddressID; 
END;

--Procedure4
CREATE PROCEDURE [dbo].[GetEmployeeByID]
  @EmployeeId INT
AS
BEGIN
SELECT e.EmployeeId,e.FirstName,e.LastName, e.Email, a.Street, a.City, a.State, a.PostalCode
FROM Employee e
INNER JOIN Address a 
ON e.AddressID = a.AddressID
WHERE e.EmployeeId = @EmployeeId;
END;


--Procedure5
CREATE PROCEDURE [dbo].[UpdateEmployeelWithAddress]
@EmployeeId INT,
@FirstName VARCHAR(100),
@LastName VARCHAR(100),
@Email VARCHAR(100),
@Street VARCHAR(255),
@City VARCHAR(100),
@State VARCHAR(100),
@PostalCode VARCHAR(28),
@AddressID INT
AS
BEGIN
--Update Address table
UPDATE Address
SET Street= @Street, City= @City, State= @State, PostalCode= @PostalCode
WHERE AddressID = @AddressID;

--Update Employee table
UPDATE Employee
SET FirstName = @FirstName, LastName = @LastName, Email= @Email, AddressID = @AddressID

WHERE EmployeeId = @EmployeeId;
END;


-- Create Employee
EXEC dbo.CreateEmployeeWithAddress
    @FirstName = 'Aman',
    @LastName = 'Verma',
    @Email = 'aman@example.com',
    @Street = '45 Sector 17',
    @City = 'Chandigarh',
    @State = 'Punjab',
    @PostalCode = '160017'
    ;

-- Get All Employees
EXEC dbo.GetAllEmployees;

-- Get Employee By ID
EXEC dbo.GetEmployeeByID @EmployeeId = 1;

-- Update Employee
EXEC dbo.UpdateEmployeelWithAddress
    @EmployeeID = 1,
    @FirstName = 'Rahul',
    @LastName = 'Sharma',
    @Email = 'rahul@example.com',
    @Street = 'New Street 45',
    @City = 'Delhi',
    @State = 'Delhi',
    @PostalCode = '110001',
    @AddressID = 1;

-- Delete Employee
EXEC dbo.DeleteEmployee @EmployeeId = 1;
