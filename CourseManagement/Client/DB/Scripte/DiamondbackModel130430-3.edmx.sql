
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2013 17:43:53
-- Generated from EDMX file: C:\Users\tjark\Documents\GitHub\Diamondback\AdminTool\Client\DB\DiamondbackModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [diamondback];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseTutor_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseTutor] DROP CONSTRAINT [FK_CourseTutor_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTutor_Tutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseTutor] DROP CONSTRAINT [FK_CourseTutor_Tutor];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_PaymentStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_PaymentCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_CourseRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_Tutor_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons_Tutor] DROP CONSTRAINT [FK_Tutor_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons_Student] DROP CONSTRAINT [FK_Student_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_User_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons_User] DROP CONSTRAINT [FK_User_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[Persons_Tutor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons_Tutor];
GO
IF OBJECT_ID(N'[dbo].[Persons_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons_Student];
GO
IF OBJECT_ID(N'[dbo].[Persons_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons_User];
GO
IF OBJECT_ID(N'[dbo].[CourseTutor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseTutor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NULL,
    [Forename] nvarchar(max)  NULL,
    [Birthdate] datetime  NULL,
    [Street] nvarchar(max)  NULL,
    [MobilePhone] nvarchar(12)  NULL,
    [Mail] nvarchar(max)  NULL,
    [Fax] nvarchar(max)  NULL,
    [PrivatePhone] nvarchar(max)  NULL,
    [Gender] tinyint  NULL,
    [Active] bit  NULL,
    [Title] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [CityCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsPaid] bit  NULL,
    [Students_Id] int  NOT NULL,
    [Courses_CourseNr] int  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseNr] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NULL,
    [AmountInEuro] decimal(6,2)  NULL,
    [Description] nvarchar(max)  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [MaxMember] decimal(3,0)  NULL,
    [MinMember] decimal(3,0)  NULL,
    [ValidityInMonth] decimal(3,0)  NULL,
    [Rooms_RoomNr] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomNr] int IDENTITY(1,1) NOT NULL,
    [Capacity] decimal(3,0)  NULL,
    [Building] nvarchar(max)  NULL,
    [Street] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [CityCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Persons_Tutor'
CREATE TABLE [dbo].[Persons_Tutor] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Persons_Student'
CREATE TABLE [dbo].[Persons_Student] (
    [IBAN] nvarchar(max)  NULL,
    [BIC] nvarchar(max)  NULL,
    [Depositor] nvarchar(max)  NULL,
    [NameOfBank] nvarchar(max)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Persons_User'
CREATE TABLE [dbo].[Persons_User] (
    [UserName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [LastLogin] datetime  NULL,
    [RegistrationDate] datetime  NULL,
    [Admin] bit  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'CourseTutor'
CREATE TABLE [dbo].[CourseTutor] (
    [Course_CourseNr] int  NOT NULL,
    [Tutors_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CourseNr] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseNr] ASC);
GO

-- Creating primary key on [RoomNr] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomNr] ASC);
GO

-- Creating primary key on [Id] in table 'Persons_Tutor'
ALTER TABLE [dbo].[Persons_Tutor]
ADD CONSTRAINT [PK_Persons_Tutor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons_Student'
ALTER TABLE [dbo].[Persons_Student]
ADD CONSTRAINT [PK_Persons_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons_User'
ALTER TABLE [dbo].[Persons_User]
ADD CONSTRAINT [PK_Persons_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Course_CourseNr], [Tutors_Id] in table 'CourseTutor'
ALTER TABLE [dbo].[CourseTutor]
ADD CONSTRAINT [PK_CourseTutor]
    PRIMARY KEY NONCLUSTERED ([Course_CourseNr], [Tutors_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Course_CourseNr] in table 'CourseTutor'
ALTER TABLE [dbo].[CourseTutor]
ADD CONSTRAINT [FK_CourseTutor_Course]
    FOREIGN KEY ([Course_CourseNr])
    REFERENCES [dbo].[Courses]
        ([CourseNr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tutors_Id] in table 'CourseTutor'
ALTER TABLE [dbo].[CourseTutor]
ADD CONSTRAINT [FK_CourseTutor_Tutor]
    FOREIGN KEY ([Tutors_Id])
    REFERENCES [dbo].[Persons_Tutor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTutor_Tutor'
CREATE INDEX [IX_FK_CourseTutor_Tutor]
ON [dbo].[CourseTutor]
    ([Tutors_Id]);
GO

-- Creating foreign key on [Students_Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_PaymentStudent]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Persons_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentStudent'
CREATE INDEX [IX_FK_PaymentStudent]
ON [dbo].[Payments]
    ([Students_Id]);
GO

-- Creating foreign key on [Courses_CourseNr] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_PaymentCourse]
    FOREIGN KEY ([Courses_CourseNr])
    REFERENCES [dbo].[Courses]
        ([CourseNr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentCourse'
CREATE INDEX [IX_FK_PaymentCourse]
ON [dbo].[Payments]
    ([Courses_CourseNr]);
GO

-- Creating foreign key on [Rooms_RoomNr] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_CourseRoom]
    FOREIGN KEY ([Rooms_RoomNr])
    REFERENCES [dbo].[Rooms]
        ([RoomNr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseRoom'
CREATE INDEX [IX_FK_CourseRoom]
ON [dbo].[Courses]
    ([Rooms_RoomNr]);
GO

-- Creating foreign key on [Id] in table 'Persons_Tutor'
ALTER TABLE [dbo].[Persons_Tutor]
ADD CONSTRAINT [FK_Tutor_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Persons_Student'
ALTER TABLE [dbo].[Persons_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Persons_User'
ALTER TABLE [dbo].[Persons_User]
ADD CONSTRAINT [FK_User_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------