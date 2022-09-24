CREATE TABLE [dbo].[Catalog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(150) NOT NULL,
	[Author] NCHAR(100)  NULL,
	[Genre]  NCHAR(50)       NOT NULL,
    [Number of copies] INT  NULL,
    [Publisher] NCHAR(150) NOT NULL,
	[Publication date] DATETIME NOT NULL,
)
