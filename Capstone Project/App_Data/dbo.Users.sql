CREATE TABLE [dbo].[Users] (
    [UserID]  CHAR (16) NOT NULL,
    [Password]  CHAR (16) NOT NULL,
    [AuthLevel] INT       NOT NULL,
    [LastLoginDate] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);



