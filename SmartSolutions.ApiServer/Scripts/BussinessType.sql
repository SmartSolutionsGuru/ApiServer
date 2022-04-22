USE [SmartSolutions.Server]
GO

INSERT INTO [dbo].[BussinessType]
           ([Description]
           ,[IsActive]
           ,[CreatedAt]
           ,[CreatedBy]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[SyncAt]
           ,[SyncBy]
           ,[Type])
     VALUES ('SoleProperitership Bussiness',1,GETDATE(),'Admin',NULL,NULL,GETDATE(),'Admin','Individual'),
			('Ltd Company',1,GETDATE(),'Admin',NULL,NULL,GETDATE(),'Admin','Company'),
			('Partnership',1,GETDATE(),'Admin',NULL,NULL,GETDATE(),'Admin','Partnership'),
			('Factory or manufactor Unit',1,GETDATE(),'Admin',NULL,NULL,GETDATE(),'Admin','Factory'),
			('Samll Unit for manufactor',1,GETDATE(),'Admin',NULL,NULL,GETDATE(),'Admin','Manufactor')