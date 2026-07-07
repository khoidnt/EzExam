SELECT 
    q.QuestionID, 
    q.QuestionText, 
    q.AnswerA, 
    q.AnswerB, 
    q.AnswerC, 
    q.AnswerD, 
    q.CorrectAnswer,
    e.ExamName -- Bắt buộc phải có trường này để đổ vào cột trống kia
FROM Questions q
INNER JOIN Exams e ON q.ExamID = e.ExamID;