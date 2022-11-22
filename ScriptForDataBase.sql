CREATE DATABASE [BookApiDapper]

USE [BookApiDapper]

CREATE TABLE [dbo].[Authors](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(60) NOT NULL,
    [Nationality] VARCHAR(50) NULL,
    [Occupation] VARCHAR(70) NOT NULL
);
GO

CREATE TABLE [dbo].[Books](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Title] VARCHAR(255) NOT NULL,
    [Publisher] VARCHAR(120) NOT NULL,
    [Pages] SMALLINT NOT NULL,
    [ISBN] VARCHAR(14) NOT NULL,
    [PublishedAt] DATETIME NOT NULL,
    [AuthorId] INT NOT NULL,

    CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
        REFERENCES [dbo].[Authors]([Id])
);
GO

-- INSERT INTO [dbo].[Authors]([Name], [Nationality], [Occupation]) VALUES('Robert C. “Uncle Bob” Martin', 'American', 'Software Engineer and Author')
-- INSERT INTO [dbo].[Authors]([Name], [Occupation]) VALUES('Eric Evans', 'Software Design and Domain Modeling')
-- INSERT INTO [dbo].[Authors]([Name], [Occupation]) VALUES('Vaughn Vernon', 'Software Developer and Architect')
-- SELECT * FROM [dbo].[Authors]

-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Clean Code: A Handbook of Agile Software Craftsmanship', 'Pearson; 1st edition', 464, '9780132350884', '2008-08-01', 1)
-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('The Clean Coder: A Code of Conduct for Professional Programmers', 'Pearson; 1st edition', 256, '0137081073', '2011-05-13', 1)
-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Clean Craftsmanship: Disciplines, Standards, and Ethics', 'Addison-Wesley Professional; 1st edition', 416, '013691571X', '2021-11-04', 1)
-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Clean Agile: Back to Basics', 'Pearson; 1st edition', 240, '0135781868', '2019-10-17', 1)
-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Clean Architecture: A Craftsman Guide to Software Structure and Design', 'Pearson; 1st edition', 432, '0134494164', '2017-09-10', 1)

-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Domain-Driven Design Distilled', 'Addison-Wesley Professional; 1st edition', 176, '0134434420', '2016-05-23', 3)
-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Implementing Domain-Driven Design', 'Addison-Wesley Professional; 1st edition', 656, '9780321834577', '2013-02-06', 3)

-- INSERT INTO 
--     [dbo].[Books]([Title], [Publisher], [Pages], [ISBN], [PublishedAt], [AuthorId])
-- VALUES('Domain-Driven Design: Tackling Complexity in the Heart of Software', 'Addison-Wesley Professional; 1st edition', 560, '0321125215', '2003-08-20', 2)


-- SELECT * FROM [dbo].[Books]