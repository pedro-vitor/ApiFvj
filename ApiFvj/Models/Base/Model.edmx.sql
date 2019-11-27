
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2019 16:37:04
-- Generated from EDMX file: C:\Users\DAVI\Desktop\Projects\ApiFvj\ApiFvj\ApiFvj\Models\Base\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [fvj_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserLead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Leads] DROP CONSTRAINT [FK_UserLead];
GO
IF OBJECT_ID(N'[dbo].[FK_UserComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_UserComment];
GO
IF OBJECT_ID(N'[dbo].[FK_LeadComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_LeadComment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Leads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leads];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Email] nvarchar(80)  NOT NULL,
    [Password] nvarchar(15)  NOT NULL,
    [Active] int  NOT NULL,
    [Createdat] datetime  NOT NULL,
    [Permission] int  NOT NULL
);
GO

-- Creating table 'Leads'
CREATE TABLE [dbo].[Leads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Email] nvarchar(80)  NOT NULL,
    [Phone] nvarchar(11)  NOT NULL,
    [Course] nvarchar(60)  NOT NULL,
    [Town] nvarchar(20)  NOT NULL,
    [Address] nvarchar(80)  NOT NULL,
    [Active] int  NOT NULL,
    [Createdat] datetime  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [LeadId] int  NOT NULL,
    [Text] nvarchar(150)  NOT NULL,
    [Active] int  NOT NULL,
    [Createdat] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Leads'
ALTER TABLE [dbo].[Leads]
ADD CONSTRAINT [PK_Leads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Leads'
ALTER TABLE [dbo].[Leads]
ADD CONSTRAINT [FK_UserLead]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLead'
CREATE INDEX [IX_FK_UserLead]
ON [dbo].[Leads]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_UserComment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComment'
CREATE INDEX [IX_FK_UserComment]
ON [dbo].[Comments]
    ([UserId]);
GO

-- Creating foreign key on [LeadId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_LeadComment]
    FOREIGN KEY ([LeadId])
    REFERENCES [dbo].[Leads]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeadComment'
CREATE INDEX [IX_FK_LeadComment]
ON [dbo].[Comments]
    ([LeadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------