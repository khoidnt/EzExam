-- Đưa hết các giá trị chữ về số 0 để không bị lỗi khi chuyển đổi
UPDATE [dbo].[Users] SET [Role] = 0 WHERE ISNUMERIC([Role]) = 0 OR [Role] IS NULL;
GO

-- Sau đó mới thực hiện chuyển kiểu
ALTER TABLE [dbo].[Users] ALTER COLUMN [Role] INT;
GO