--Veritabanı oluşturmak için database sonrasına arzu ettiğin ismi ver
create database RentalCarDb;

--Colors tablosunu oluşturup id kolonunu birincil anahtar olarak belirledim.
CREATE TABLE Colors (
    ID int NOT NULL,
    Name varchar(255),
    PRIMARY KEY (ID)
);
--Brands tablosunu oluşturup id kolonunu birincil anahtar olarak belirledim.
CREATE TABLE Brands (
    ID int NOT NULL,
    Name varchar(255),
    PRIMARY KEY (ID)
);

--Cars tablosunda da Id kolonu birincil anahtar. BrandId ve ColorId diğer tablolardan beslenen bir değer
--bu yüzden foreign key olarak belirledim. Bunu yapmasanız da olur.
CREATE TABLE Cars (
    ID int NOT NULL,
    BrandId int,
    ColorId int,
    ModelYear int,
    DailyPrice int,
    Description varchar(255),
    PRIMARY KEY (ID),
    FOREIGN KEY (BrandId) REFERENCES Brands(ID),
    FOREIGN KEY (ColorId) References Colors(ID)
);