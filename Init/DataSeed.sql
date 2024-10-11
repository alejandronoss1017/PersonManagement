-- Seed data into Person table
IF NOT EXISTS (SELECT * FROM Person WHERE Id = 1)
    INSERT INTO Person (Id, Name, LastName, Gender, Age) VALUES (1, 'John', 'Doe', 'M', 30);
IF NOT EXISTS (SELECT * FROM Person WHERE Id = 2)
    INSERT INTO Person (Id, Name, LastName, Gender, Age) VALUES (2, 'Jane', 'Smith', 'F', 25);
IF NOT EXISTS (SELECT * FROM Person WHERE Id = 3)
    INSERT INTO Person (Id, Name, LastName, Gender, Age) VALUES (3, 'Alice', 'Johnson', 'F', 28);
IF NOT EXISTS (SELECT * FROM Person WHERE Id = 4)
    INSERT INTO Person (Id, Name, LastName, Gender, Age) VALUES (4, 'Bob', 'Brown', 'M', 35);
GO

-- Seed data into Profession table
IF NOT EXISTS (SELECT * FROM Profession WHERE Id = 1)
    INSERT INTO Profession (Id, Name, Description) VALUES (1, 'Software Engineer', 'Develops software applications');
IF NOT EXISTS (SELECT * FROM Profession WHERE Id = 2)
    INSERT INTO Profession (Id, Name, Description) VALUES (2, 'Data Scientist', 'Analyzes and interprets complex data');
IF NOT EXISTS (SELECT * FROM Profession WHERE Id = 3)
    INSERT INTO Profession (Id, Name, Description) VALUES (3, 'Product Manager', 'Oversees product development');
GO

-- Seed data into Education table
IF NOT EXISTS (SELECT * FROM Education WHERE IdProfession = 1 AND IdPerson = 1)
    INSERT INTO Education (IdProfession, IdPerson, Date, University) VALUES (1, 1, '2010-06-15', 'MIT');
IF NOT EXISTS (SELECT * FROM Education WHERE IdProfession = 2 AND IdPerson = 2)
    INSERT INTO Education (IdProfession, IdPerson, Date, University) VALUES (2, 2, '2012-05-20', 'Stanford');
IF NOT EXISTS (SELECT * FROM Education WHERE IdProfession = 3 AND IdPerson = 3)
    INSERT INTO Education (IdProfession, IdPerson, Date, University) VALUES (3, 3, '2014-07-10', 'Harvard');
GO

-- Seed data into Phone table
IF NOT EXISTS (SELECT * FROM Phone WHERE Number = '123-456-7890')
    INSERT INTO Phone (Number, Carrier, Owner) VALUES ('123-456-7890', 'Verizon', 1);
IF NOT EXISTS (SELECT * FROM Phone WHERE Number = '234-567-8901')
    INSERT INTO Phone (Number, Carrier, Owner) VALUES ('234-567-8901', 'AT&T', 2);
IF NOT EXISTS (SELECT * FROM Phone WHERE Number = '345-678-9012')
    INSERT INTO Phone (Number, Carrier, Owner) VALUES ('345-678-9012', 'T-Mobile', 3);
IF NOT EXISTS (SELECT * FROM Phone WHERE Number = '456-789-0123')
    INSERT INTO Phone (Number, Carrier, Owner) VALUES ('456-789-0123', 'Sprint', 4);
GO