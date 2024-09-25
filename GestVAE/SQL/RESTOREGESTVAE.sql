USE [master]
GO
ALTER DATABASE [GESTVAE] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
DROP DATABASE [GESTVAE]
GO
RESTORE DATABASE [GESTVAE] FROM  DISK = N'C:\temp\gestvae.bak' WITH  FILE = 1,  MOVE N'GESTVAETU' TO N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GESTVAETU.mdf',  MOVE N'GESTVAETU_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GESTVAETU.ldf',  NOUNLOAD,  STATS = 5

GO
USE [GESTVAE]
GO

/****** Object:  User [gestvae]    Script Date: 20/09/2024 08:30:58 ******/
DROP USER [gestvae]
GO

/****** Object:  User [gestvae]    Script Date: 20/09/2024 08:30:58 ******/
CREATE USER [gestvae] FOR LOGIN [gestvae] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [GESTVAE]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [gestvae]
GO
USE [GESTVAE]
GO
ALTER ROLE [db_datareader] ADD MEMBER [gestvae]
GO
USE [GESTVAE]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [gestvae]
GO
USE [GESTVAE]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [gestvae]
GO
USE [GESTVAE]
GO
ALTER ROLE [db_owner] ADD MEMBER [gestvae]
GO
Use [Master]

