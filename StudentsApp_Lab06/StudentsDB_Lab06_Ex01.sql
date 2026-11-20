CREATE DATABASE StudentsDB_Lab06;
GO
USE StudentsDB_Lab06;
GO

CREATE TABLE tblStudents (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    EnrollmentDate DATE NOT NULL
);
GO

INSERT INTO tblStudents (FirstName, LastName, Email, EnrollmentDate) VALUES
('Trung', 'Pham', 'trung.pham@seuni.com', '2024-01-15'),
('Michael', 'Pham', 'michael.pham@seuni.com', '2024-02-20');
GO