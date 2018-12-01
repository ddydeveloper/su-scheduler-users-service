/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT TOP 1 Id FROM Companies) 
BEGIN

	INSERT INTO Companies ([Name])
			  SELECT N'Samsung'
	UNION ALL SELECT N'Xaomi'
	UNION ALL SELECT N'Huawei'
	UNION ALL SELECT N'Apple'
	UNION ALL SELECT N'Meizu'

	INSERT INTO [dbo].[Positions] ([Name])
			  SELECT N'CEO'
	UNION ALL SELECT N'CTO'
	UNION ALL SELECT N'QA engeneer'
	UNION ALL SELECT N'Developer'
	UNION ALL SELECT N'Lead developer'

	INSERT INTO [dbo].[Users] ([FirstName], [LastName], [CompanyId], [PositionId])
			  SELECT N'Nathan', N'Fillion', 0, 0
	UNION ALL SELECT N'Dan', N'Khomyakov', 0, 1
	UNION ALL SELECT N'Artur', N'Kosarev', 0, 2
	UNION ALL SELECT N'William', N'Redcliff', 0, 2
	UNION ALL SELECT N'Naomi', N'Swift', 0, 3
	UNION ALL SELECT N'Jeremy', N'Carry', 0, 3
	UNION ALL SELECT N'Deontei', N'Kuznetsov', 0, 3
	UNION ALL SELECT N'Garry', N'Carrager', 0, 4

	UNION ALL SELECT N'Philipp', N'Morrisson', 1, 0
	UNION ALL SELECT N'Danny', N'Marko', 1, 2
	UNION ALL SELECT N'Christian', N'Whittaker', 1, 3
	UNION ALL SELECT N'Yoel', N'Ortega', 1, 3
	UNION ALL SELECT N'Chris', N'Cyborg', 1, 4

	UNION ALL SELECT N'Neil', N'Lemon', 2, 0
	UNION ALL SELECT N'Luis', N'Armstrong', 2, 1
	UNION ALL SELECT N'David', N'Southerland', 2, 1

END