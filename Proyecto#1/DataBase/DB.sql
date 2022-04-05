--Create database UnedProyectos;
Use UnedProyectos;

CREATE TABLE USERS(
	Id INT IDENTITY(1,1) not null,
	Name VARCHAR(50) not null,
	lastName VARCHAR(50) not null,
	Surname VARCHAR(50) null,
	Email VARCHAR(150) not null,
	Password VARCHAR(500) not null,
	Constraint PK_USERS Primary Key(Email) 
);
--DROP TABLE USERS;
SELECT * FROM USERS;

CREATE TABLE USERS_AUTHENTICATION
(
	Id INT IDENTITY(1,1) not null,
	Email VARCHAR(150) not null,
	Code VARCHAR(10) not null,
	AuthDate SMALLDATETIME not null,
	ValidMinutes INT not null,
	Status INT not null,
	Constraint FK_USERS_AUTHENTICATION Foreign Key (Email) REFERENCES USERS(Email),
	Constraint PK_USERS_AUTHENTICATION Primary Key(Email, Code) 
);

SELECT * FROM USERS_AUTHENTICATION;

CREATE TABLE TYPE_AIRPLANE
(
	IdTypeAirplane INT IDENTITY(1,1) not null,
	ShortDes VARCHAR(50) not null,
	Description VARCHAR(200),
	Constraint PK_TYPE_AIRPLANE Primary Key(IdTypeAirplane) 
);

--DROP TABLE TYPE_AIRPLANE
SELECT * FROM TYPE_AIRPLANE;

CREATE TABLE AIRPLANE
(
	IdAirplane INT IDENTITY(1,1) not null,
	Name VARCHAR(50) not null,
	Description VARCHAR(200),
	TotalRows INT not null,
	TotalSeatingXRow INT not null,
	TotalFirstRows INT not null,
	TotalFirstxFristRow INT not null,
	IdTypeAirplane INT not null,
	Constraint FK_AIRPLANE Foreign Key (IdTypeAirplane) REFERENCES TYPE_AIRPLANE(IdTypeAirplane),
	Constraint PK_AIRPLANE Primary Key(Name) 
);

--DROP TABLE AIRPLANE
SELECT * FROM AIRPLANE;

CREATE TABLE COUNTRY 
(
	IdCountry INT IDENTITY(1,1) not null,
	Name VARCHAR(200) not null,
	Description VARCHAR(300) null,
	Constraint PK_COUNTRY Primary Key(IdCountry) 
);

--DROP TABLE COUNTRY
SELECT * FROM COUNTRY;


CREATE TABLE GENDER
(
	IdGender INT IDENTITY(1,1) not null,
	Gender VARCHAR(50) not null,
	Constraint PK_GENDER Primary Key(IdGender) 
);

--DROP TABLE GENDER
SELECT * FROM GENDER;

CREATE TABLE POSITION
(
	IdPosition INT IDENTITY(1,1) not null,
	Position VARCHAR(50) not null,
	Description VARCHAR(200) null,
	Constraint PK_POSITION Primary Key(IdPosition) 
);

--DROP TABLE POSITION
SELECT * FROM POSITION;

CREATE TABLE PERSON
(
	IdPerson INT IDENTITY(1,1) not null,
	Identification VARCHAR(60) not null,
	Name VARCHAR(50) not null,
	LastName VARCHAR(60) not null,
	Surname VARCHAR(60) null,
	Email VARCHAR(200) not null,
	BirthDate DATE null,
	IdGender INT not null,
	IdPosition INT not null,
	Constraint FK_PERSON_GENDER Foreign Key (IdGender) REFERENCES GENDER(IdGender),
	Constraint FK_PERSON_POSITION Foreign Key (IdPosition) REFERENCES POSITION(IdPosition),
	Constraint PK_PERSON Primary Key(Identification) 
);

--DROP TABLE PERSON
SELECT * FROM PERSON;

CREATE TABLE LUGGAGE
(
	IdLuggage INT IDENTITY(1,1) not null,
	ShortDes VARCHAR(50) not null,
	Description VARCHAR(150) null,
	MaxKilos INT not null,
	Price NUMERIC(20,4) not null 
	Constraint PK_LUGGAGE Primary Key(IdLuggage) 
);

--DROP TABLE LUGGAGE
SELECT * FROM LUGGAGE;

CREATE TABLE CREW
(
	IdCrew INT IDENTITY(1,1) not null,
	Description VARCHAR(150) not null,
	Constraint PK_CREW Primary Key(IdCrew) 
);

--DROP TABLE CREW
SELECT * FROM CREW;

CREATE TABLE CREWPERSON
(
	IdCrew INT not null,
	IdPerson VARCHAR(60) not null,
	Constraint PK_CREWPERSON Primary Key(IdCrew,IdPerson),
	Constraint FK_CREWPERSON_CREW Foreign Key (IdCrew) REFERENCES CREW(IdCrew),
	Constraint FK_CREWPERSON_PERSON Foreign Key (IdPerson) REFERENCES PERSON(Identification)
);


--DROP TABLE CREWPERSON
SELECT * FROM CREWPERSON;

CREATE TABLE FLIGHT
(
	IdFlight INT IDENTITY(1,1) not null,
	DateFlight DATETIME not null,
	Direct VARCHAR(1) not null,
	IdOriginCountry INT not null,
	IdDestinationCountry INT not null,
	Duration VARCHAR(20) not null,
	IdCrew INT not null,
	Airplane VARCHAR(50) not null,
	PriceEconomical NUMERIC(20,4) not null,
	PriceFrist NUMERIC(20,4) not null,
	Constraint PK_FLIGHT Primary Key(IdFlight),
	Constraint FK_FLIGHT_COUNTRY Foreign Key (IdOriginCountry) REFERENCES COUNTRY(IdCountry),
	CONSTRAINT FK_FLIGHT_COUNTRY_DESTINATION Foreign Key (IdDestinationCountry) REFERENCES COUNTRY(IdCountry),	
	CONSTRAINT FK_FLIGHT_AIRPLANE Foreign Key (Airplane) REFERENCES AIRPLANE(Name),
	Constraint FK_FLIGHT_CREW Foreign Key (IdCrew) REFERENCES CREW(IdCrew),
);

--DROP TABLE FLIGHT
SELECT * FROM FLIGHT;

CREATE TABLE TICKET
(
	IdTicket INT IDENTITY(1,1) not null,
	IdUser  VARCHAR(150) not null,
	IdFlight  INT not null,
	IdLuggage INT not null,
	SeatNumber VARCHAR(4) not null,
	Constraint PK_TICKET Primary Key(IdTicket),
	Constraint FK_TICKET_FLIGHT Foreign Key (IdFlight) REFERENCES FLIGHT(IdFlight),
	Constraint FK_TICKET_USERS Foreign Key (IdUser) REFERENCES USERS(Email),
	Constraint FK_TICKET_LUGGAGE Foreign Key (IdLuggage) REFERENCES LUGGAGE(IdLuggage)
);

--DROP TABLE TICKET
SELECT * FROM TICKET;