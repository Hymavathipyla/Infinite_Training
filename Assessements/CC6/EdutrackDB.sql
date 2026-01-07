create database Edutrack;

create table Students(
  StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Department VARCHAR(50) NOT NULL,
    YearOfStudy INT NOT NULL
);

insert into  Students (FullName, Email, Department, YearOfStudy) values
('Hymapyla', 'Hymapyla@example.edu', 'Computer Science', 2),
('uday Sharma', 'uday.sharma@example.edu', 'Electronics', 3),
('Vikram krishna', 'vikram.krishna@example.edu', 'Mechanical', 1),
('Nihal dev', 'Nihal dev@example.edu', 'Computer Science', 4),
('viddu ', 'viddu@example.edu', 'Civil', 2);

create table Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Semester VARCHAR(20) NOT NULL
);

insert into Courses (CourseName, Credits, Semester) values
('Data Structures', 4, 'Spring'),
('Database Systems', 3, 'Spring'),
('Operating Systems', 4, 'Fall'),
('Circuit Analysis', 3, 'Fall'),
('Thermodynamics', 3, 'Spring'),
('Structural Engineering', 4, 'Fall');

create table Enrollments (
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATETIME NOT NULL DEFAULT GETDATE(),
    Grade VARCHAR(5) NULL,
    CONSTRAINT FK_Enroll_Student FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    CONSTRAINT FK_Enroll_Course FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
    CONSTRAINT UQ_Enroll UNIQUE (StudentId, CourseId) 
);


INSERT INTO Enrollments (StudentId, CourseId, EnrollDate, Grade) VALUES
(1, 1, '2025-01-15', 'A'),
(1, 2, '2025-01-20', 'B'),
(2, 4, '2025-02-05', 'A'),
(3, 5, '2025-03-10', NULL),
(4, 1, '2025-01-18', 'C'),
(4, 3, '2025-02-12', NULL),
(5, 6, '2025-03-25', 'B');

select * from Students;
select * from Courses;
select * from Enrollments;


create procedure usp_GetCoursesBySemester
    @semester NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    select CourseId, CourseName, Credits, Semester
    from Courses
    where Semester = @semester;
END

EXEC usp_GetCoursesBySemester @semester = 'spring';



