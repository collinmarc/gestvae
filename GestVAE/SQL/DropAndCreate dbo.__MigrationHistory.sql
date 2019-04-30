USE [GESTVAE]
GO

/****** Objet : Table [dbo].[__MigrationHistory] Date du script : 29/04/2019 13:29:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[__MigrationHistory];


GO
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL
);

INSERT INTO [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201904110802080_Install du 11-04-2019', N'GestVAEcls.Migrations.Configuration', <Binary Data>, N'6.2.0-61023')



