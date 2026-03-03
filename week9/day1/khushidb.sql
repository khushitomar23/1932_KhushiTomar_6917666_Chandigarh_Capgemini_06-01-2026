CREATE DATABASE khushidb
GO

USE khushidb
GO

-- Create Table
CREATE TABLE Employeetb(
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(20),
    EmpDesg VARCHAR(50),
    EmpDOJ DATETIME,
    EmpSal INT,
    EmpDept INT
)
GO
drop table Employeetb;
-- Insert Data (Correct Date Format)
INSERT INTO Employeetb VALUES
(101,'Krishna','ProjManager','2010-08-07',45000,10),
(102,'Kumari','Manager','2010-08-06',50000,20),
(103,'Amit','Manager','2010-09-07',44000,30),
(104,'Ravi','ProjManager','2010-05-07',55000,20)
GO

---------------------------------------------------
-- Delete Procedure (Simple)
---------------------------------------------------
CREATE PROC SP_DelRec
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = 105
END
GO

---------------------------------------------------
-- Delete Procedure with Parameter
---------------------------------------------------
CREATE PROC sp_DelRecP 
    @PempId INT
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = @PempId
END
GO

---------------------------------------------------
-- Insert Procedure
---------------------------------------------------
CREATE PROC SPEmp_Insert
(
    @PEmpId INT,
    @PEmpName VARCHAR(20),
    @PEmpDesg VARCHAR(50),
    @PEmpDOJ DATETIME,
    @PEmpSal INT,
    @PEmpDept INT
)
AS
BEGIN
    INSERT INTO Employeetb
    VALUES (@PEmpId, @PEmpName, @PEmpDesg, @PEmpDOJ, @PEmpSal, @PEmpDept)
END
GO

---------------------------------------------------
-- Update Procedure
---------------------------------------------------
CREATE PROC SPEmp_Update
(
    @PEmpId INT,
    @PEmpName VARCHAR(20),
    @PEmpDesg VARCHAR(50),
    @PEmpDOJ DATETIME,
    @PEmpSal INT,
    @PEmpDept INT
)
AS
BEGIN
    UPDATE Employeetb
    SET 
        EmpName = @PEmpName,
        EmpDesg = @PEmpDesg,
        EmpDOJ = @PEmpDOJ,
        EmpSal = @PEmpSal,
        EmpDept = @PEmpDept
    WHERE EmpId = @PEmpId
END
GO

---------------------------------------------------
-- Delete by EmpId
---------------------------------------------------
CREATE PROC SPEmp_Del 
    @PEmpId INT
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = @PEmpId
END
GO

---------------------------------------------------
-- Get Salary (OUTPUT Parameter)
---------------------------------------------------
CREATE PROC SPGetSal
(
    @PEmpId INT,
    @PEmpSal INT OUTPUT
)
AS
BEGIN
    SELECT @PEmpSal = EmpSal
    FROM Employeetb
    WHERE EmpId = @PEmpId
END
GO

---------------------------------------------------
-- Get Full Employee Data (OUTPUT Parameters)
---------------------------------------------------
CREATE PROC SPGetData
(
    @PEmpId INT,
    @PEmpName VARCHAR(50) OUTPUT,
    @PEmpDesig VARCHAR(50) OUTPUT,
    @PEmpDOJ DATETIME OUTPUT,
    @PEmpSal INT OUTPUT,
    @PEmpDept INT OUTPUT
)
AS
BEGIN
    SELECT 
        @PEmpName = EmpName,
        @PEmpDesig = EmpDesg,
        @PEmpDOJ = EmpDOJ,
        @PEmpSal = EmpSal,
        @PEmpDept = EmpDept
    FROM Employeetb
    WHERE EmpId = @PEmpId
END
GO