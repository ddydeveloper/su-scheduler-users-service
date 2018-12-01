CREATE TABLE [dbo].[Positions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Created] DATETIME NOT NULL DEFAULT (GETDATE()) 
)
