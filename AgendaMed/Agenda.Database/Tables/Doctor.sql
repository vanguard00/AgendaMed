CREATE TABLE [dbo].[Doctor]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Name varchar(100) not null,
	CMR varchar(20) not null,
	CPF varchar(14) not null,
	DateOfBirth datetime,
	Specialty UNIQUEIDENTIFIER NOT NULL,
	foreign key(Specialty) references Specialty(Id)
)
