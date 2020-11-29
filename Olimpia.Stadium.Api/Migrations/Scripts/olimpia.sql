USE [Olimpia]
GO

INSERT INTO [dbo].[Stadiums] ([Created],[IsDeleted],[Deleted],[Name],[Location], [MaxCapacity]) VALUES (getdate(),0,null,'AC Milan','Anywhere', 30)

INSERT INTO [dbo].[Gates]([Created],[IsDeleted],[Deleted],[Name],[Location],[StadiumId]) VALUES           
(getdate(),0,null,'North Gate','North',1),
(getdate(),0,null,'South Gate','South',1),
(getdate(),0,null,'West Gate','West',1),
(getdate(),0,null,'East Gate','East',1)
GO


