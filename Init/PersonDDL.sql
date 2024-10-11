-- SQL Server DDL for PersonManagement schema

-- Create the database if it does not exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PersonManagement')
    BEGIN
        CREATE DATABASE PersonManagement;
    END
GO

-- Use the database
USE PersonManagement;
GO

-- Create the Person table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Person')
    BEGIN
        CREATE TABLE Person (
                                Id INT NOT NULL,
                                Name VARCHAR(45) NOT NULL,
                                LastName VARCHAR(45) NOT NULL,
                                Gender CHAR(1) NOT NULL CHECK (Gender IN ('M', 'F')),
                                Age INT NULL,
                                PRIMARY KEY (Id)
        );
    END
GO

-- Create the Profession table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Profession')
    BEGIN
        CREATE TABLE Profession (
                                    Id INT NOT NULL,
                                    Name VARCHAR(90) NOT NULL,
                                    Description TEXT NULL,
                                    PRIMARY KEY (Id)
        );
    END
GO

-- Create the Education table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Education')
    BEGIN
        CREATE TABLE Education (
                                   IdProfession INT NOT NULL,
                                   IdPerson INT NOT NULL,
                                   Date DATE NULL,
                                   University VARCHAR(50) NULL,
                                   PRIMARY KEY (IdProfession, IdPerson),
                                   CONSTRAINT EducationPersonFk FOREIGN KEY (IdPerson) REFERENCES Person (Id),
                                   CONSTRAINT EducationProfessionFk FOREIGN KEY (IdProfession) REFERENCES Profession (Id)
        );
    END
GO

-- Create the Phone table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Phone')
    BEGIN
        CREATE TABLE Phone (
                               Number VARCHAR(15) NOT NULL,
                               Carrier VARCHAR(45) NOT NULL,
                               Owner INT NOT NULL,
                               PRIMARY KEY (Number),
                               CONSTRAINT PhonePersonFk FOREIGN KEY (Owner) REFERENCES Person (Id)
        );
    END
GO