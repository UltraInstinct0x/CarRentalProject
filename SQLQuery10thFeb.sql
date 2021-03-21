create table Users(
	Id int,
	FirstName varchar(255),
	LastName varchar(255),
	Email varchar(255) not null,
	Password varchar(255) not null
	Primary key (Id))

create table Customers(
	Id int, UserId int,
	CompanyName varchar(255)
	Primary Key (Id)
	foreign key (UserId) References Users(Id))

create table Rentals(
	Id int,
	CarId int,
	CustomerId int,
	RentDate date,
	ReturnDate date,
	primary key (Id),
	foreign key (CarId) references Cars(Id),
	foreign key (CustomerId) references Customers(Id))
