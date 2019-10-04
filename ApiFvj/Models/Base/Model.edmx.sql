
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/03/2019 17:06:05
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(80)  NOT NULL,
    [email] nvarchar(80)  NOT NULL,
    [password] nvarchar(15)  NOT NULL,
    [active] int  NOT NULL,
    [createdat] datetime  NOT NULL
);
GO

-- Creating table 'Leads'
CREATE TABLE [dbo].[Leads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [name] nvarchar(80)  NOT NULL,
    [email] nvarchar(80)  NOT NULL,
    [numberphone] nvarchar(11)  NOT NULL,
    [desiredcourse] nvarchar(20)  NOT NULL,
    [town] nvarchar(20)  NOT NULL,
    [address] nvarchar(80)  NOT NULL,
    [active] int  NOT NULL,
    [createdat] datetime  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
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