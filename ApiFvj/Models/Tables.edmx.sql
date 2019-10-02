
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/01/2019 20:59:47
-- Generated from EDMX file: C:\Users\DAVI\Desktop\Projects\ApiFvj\ApiFvj\ApiFvj\Models\Tables.edmx
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

IF OBJECT_ID(N'[dbo].[FK_UsersLead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Leads] DROP CONSTRAINT [FK_UsersLead];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_UsersComment];
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
    [name] nvarchar(50)  NOT NULL,
    [email] nvarchar(80)  NOT NULL,
    [password] nvarchar(20)  NOT NULL,
    [active] int  NOT NULL,
    [createdat] datetime  NOT NULL
);
GO

-- Creating table 'Leads'
CREATE TABLE [dbo].[Leads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersId] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [numberphone] nvarchar(11)  NOT NULL,
    [desiredcourse] nvarchar(25)  NOT NULL,
    [town] nvarchar(max)  NOT NULL,
    [adress] nvarchar(50)  NOT NULL,
    [email] nvarchar(80)  NOT NULL,
    [active] int  NOT NULL,
    [createdat] datetime  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsersId] int  NOT NULL,
    [LeadId] int  NOT NULL,
    [text] nvarchar(150)  NOT NULL,
    [createdat] datetime  NOT NULL
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

-- Creating foreign key on [UsersId] in table 'Leads'
ALTER TABLE [dbo].[Leads]
ADD CONSTRAINT [FK_UsersLead]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersLead'
CREATE INDEX [IX_FK_UsersLead]
ON [dbo].[Leads]
    ([UsersId]);
GO

-- Creating foreign key on [UsersId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_UsersComment]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersComment'
CREATE INDEX [IX_FK_UsersComment]
ON [dbo].[Comments]
    ([UsersId]);
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