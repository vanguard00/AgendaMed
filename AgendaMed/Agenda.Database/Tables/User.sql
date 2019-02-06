CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Username varchar(20) not null,
	Password varchar(200) not null,
	Name varchar(100) not null,
	Active bit
)
