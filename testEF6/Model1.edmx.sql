
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2019 17:29:57
-- Generated from EDMX file: N:\2pConsultants\EHESP\APP\GestVAE\testEF6\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GESTVAE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T1];
GO
IF OBJECT_ID(N'[dbo].[T2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T2];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T1'
CREATE TABLE [dbo].[T1] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [dateCreation] datetime  NOT NULL,
    [dateModif] datetime  NOT NULL,
    [bDeleted] bit  NOT NULL
);
GO

-- Creating table 'T2'
CREATE TABLE [dbo].[T2] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [dateCreation] datetime  NOT NULL,
    [dateModif] datetime  NOT NULL,
    [bDeleted] bit  NOT NULL,
    [T1ID1] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'T1'
ALTER TABLE [dbo].[T1]
ADD CONSTRAINT [PK_T1]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'T2'
ALTER TABLE [dbo].[T2]
ADD CONSTRAINT [PK_T2]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [T1ID1] in table 'T2'
ALTER TABLE [dbo].[T2]
ADD CONSTRAINT [FK_T1T2]
    FOREIGN KEY ([T1ID1])
    REFERENCES [dbo].[T1]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T1T2'
CREATE INDEX [IX_FK_T1T2]
ON [dbo].[T2]
    ([T1ID1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------