CREATE TABLE ExamResults
(
    ResultID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    ExamID INT,
    Score FLOAT,
    CreatedAt DATETIME DEFAULT GETDATE()
);