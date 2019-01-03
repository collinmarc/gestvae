
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2018 16:31:35
-- Generated from EDMX file: C:\Users\COLLIN\source\repos\ExpenseIt\DataGridSQLExample\AdventureWorksModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
-- USE [product];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Ville] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------