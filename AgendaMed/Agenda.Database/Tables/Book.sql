CREATE TABLE [dbo].[Book]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Doctor UNIQUEIDENTIFIER NOT NULL,
	[User] UNIQUEIDENTIFIER NOT NULL,
	BookDate datetime not null,
	foreign key (Doctor) references Doctor(Id),
	foreign key ([User]) references [User](Id)
)
