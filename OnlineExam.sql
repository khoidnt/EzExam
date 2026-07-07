CREATE TABLE [dbo].[Users] (
    [UserID]      INT            IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (50)  NOT NULL,
    [Password]    NVARCHAR (255) NOT NULL,
    [Role]        INT            DEFAULT ((0)) NOT NULL,
    [FullName]    NVARCHAR (100) NULL,
    [StudentCode] NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);
GO