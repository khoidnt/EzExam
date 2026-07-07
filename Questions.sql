CREATE TABLE Questions
(
    QuestionID INT IDENTITY(1,1) PRIMARY KEY,
    ExamID INT,
    QuestionText NVARCHAR(500),
    AnswerA NVARCHAR(200),
    AnswerB NVARCHAR(200),
    AnswerC NVARCHAR(200),
    AnswerD NVARCHAR(200),
    CorrectAnswer NVARCHAR(10)
);