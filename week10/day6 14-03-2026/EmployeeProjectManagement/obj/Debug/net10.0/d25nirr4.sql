IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Departments] (
    [DepartmentId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId])
);

CREATE TABLE [Projects] (
    [ProjectId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([ProjectId])
);

CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [DepartmentId] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId]),
    CONSTRAINT [FK_Employees_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId]) ON DELETE CASCADE
);

CREATE TABLE [EmployeeProjects] (
    [EmployeeId] int NOT NULL,
    [ProjectId] int NOT NULL,
    [AssignedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_EmployeeProjects] PRIMARY KEY ([EmployeeId], [ProjectId]),
    CONSTRAINT [FK_EmployeeProjects_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeProjects_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);

CREATE INDEX [IX_EmployeeProjects_ProjectId] ON [EmployeeProjects] ([ProjectId]);

CREATE INDEX [IX_Employees_DepartmentId] ON [Employees] ([DepartmentId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260314054521_InitialCreate', N'10.0.0');

COMMIT;
GO

