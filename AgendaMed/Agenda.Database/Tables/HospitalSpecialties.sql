CREATE TABLE [dbo].[HospitalSpecialties]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Hospital UNIQUEIDENTIFIER NOT NULL,
	Specialty UNIQUEIDENTIFIER NOT NULL
	foreign key (Hospital) references Hospital(Id),
	foreign key (Specialty) references Specialty(Id)
)
