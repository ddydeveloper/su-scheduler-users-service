CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [TimeZoneId] NVARCHAR(500) NOT NULL DEFAULT (N'UTC'), 
    [Created] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [CompanyId] INT NOT NULL, 
    [PositionId] INT NOT NULL, 
    CONSTRAINT [FK_Users_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [Companies]([Id]), 
    CONSTRAINT [FK_Users_Positions] FOREIGN KEY ([PositionId]) REFERENCES [Positions]([Id]) 
)
