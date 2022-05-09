CREATE TABLE SPECIALTY_VET(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(100) not null,
	Description VARCHAR(300) null,
	Constraint PK_SPECIALTY_VET Primary Key(Id) 	
);


CREATE TABLE SCHEDULE (
	Id INT IDENTITY(1,1) not null,
	AppointmentDate Date not null,
	QuantityXHour INT not null,
	Hours VARCHAR(10) null,
	IdSpecialty INT not null,
	Constraint PK_SCHEDULE Primary Key(Id),
	Constraint FK_SCHEDULE Foreign Key (IdSpecialty) REFERENCES SPECIALTY_VET(Id)
);


CREATE TABLE ANIMAL_TYPE(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(100) not null,
	Description VARCHAR(300) null,
	Constraint PK_ANIMAL_TYPE Primary Key(Id) 	
);


CREATE TABLE ANIMAL_RAZE(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(100) not null,
	Description VARCHAR(300) null,
	IdAnimalType INT not null,
	Constraint PK_ANIMAL_RAZE Primary Key(Id),	
	Constraint FK_ANIMAL_RAZE Foreign Key (IdAnimalType) REFERENCES ANIMAL_TYPE(Id)
);


CREATE TABLE ANIMAL(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(100) not null,
	Description VARCHAR(300) null,
	Age INT null,
	IdAnimalType INT not null,
	IdAnimalRaze INT not null,
	Constraint PK_ANIMAL Primary Key(Id),	
	Constraint FK_ANIMALTYPE Foreign Key (IdAnimalType) REFERENCES ANIMAL_TYPE(Id),
	Constraint FK_ANIMALRAZE Foreign Key (IdAnimalRaze) REFERENCES ANIMAL_RAZE(Id)
);


CREATE TABLE APPOINTMENT_VET(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(100) not null,
	IdAnimal INT not null,
	IdShedule INT not null,
	IdUser VARCHAR(150) not null,
	IdSpecialtyVet INT not null,
	Constraint PK_APPOINTEMN_VET Primary Key(Id),	
	Constraint FK_APPOINTEMN_VET_ANIMAL Foreign Key (IdAnimal) REFERENCES ANIMAL(Id),
	Constraint FK_APPOINTEMN_VET_SHEDULE Foreign Key (IdShedule) REFERENCES SCHEDULE(Id),
	Constraint FK_APPOINTEMN_VET_USER Foreign Key (IdUser) REFERENCES USERS(Email),
	Constraint FK_APPOINTEMN_VET_SPECIALTY_VET Foreign Key (IdSpecialtyVet) REFERENCES SPECIALTY_VET(Id)

); 

