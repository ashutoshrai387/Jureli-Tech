CREATE TABLE Students (
    StudentId INT PRIMARY KEY AUTO_INCREMENT,
    StudentName VARCHAR(255) NOT NULL
);

CREATE TABLE Classes (
    ClassId INT PRIMARY KEY AUTO_INCREMENT,
    ClassName VARCHAR(255) NOT NULL
);

CREATE TABLE Subjects (
    SubjectId INT PRIMARY KEY AUTO_INCREMENT,
    SubjectName VARCHAR(255) NOT NULL
);

CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY AUTO_INCREMENT,
    StudentId INT,
    ClassId INT,
    SubjectId INT,
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    FOREIGN KEY (ClassId) REFERENCES Classes(ClassId),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
);