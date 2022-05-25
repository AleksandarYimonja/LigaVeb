CREATE DATABASE Liga;

USE Liga;

CREATE TABLE Korisnik
(
ID INT IDENTITY(1,1) PRIMARY KEY,
Imejl NVARCHAR(20),
Lozinka NVARCHAR(20),
Uloga INT
)

CREATE TABLE Sezona
(
ID INT IDENTITY(1,1) PRIMARY KEY,
Naziv NVARCHAR(7)--izgleda ovako: 2021-22
)

CREATE TABLE Klub
(
ID INT IDENTITY(1,1) PRIMARY KEY,
Naziv NVARCHAR(20)
)
/*
DROP TABLE Sezona;
DROP TABLE Korisnik;
DROP TABLE Klub;
DROP TABLE Igrac;
*/
CREATE TABLE Igrac
(
ID INT IDENTITY(1,1) PRIMARY KEY,
Ime NVARCHAR(20),
Prezime NVARCHAR(20),
KlubID INT,
FOREIGN KEY(KlubID) REFERENCES Klub(ID)
)

CREATE TABLE Mec
(
ID INT IDENTITY(1,1) PRIMARY KEY,
Klub1ID INT,
Klub2ID INT,
Datum DATE,
SezonaID INT,
FOREIGN KEY(Klub1ID) REFERENCES Klub(ID),
FOREIGN KEY(Klub2ID) REFERENCES Klub(ID),
FOREIGN KEY(SezonaID) REFERENCES Sezona(ID)
)

CREATE TABLE Gol
(
ID INT IDENTITY(1,1) PRIMARY KEY,
StrelacID INT,
AsistiraoID INT,
MecID INT,
FOREIGN KEY(StrelacID) REFERENCES Igrac(ID),
FOREIGN KEY(AsistiraoID) REFERENCES Igrac(ID),
FOREIGN KEY(MecID) REFERENCES Mec(ID)
)

CREATE VIEW MecPogled
AS
SELECT Mec.ID, Prvi.Naziv AS Klub1,
(SELECT COUNT(*) FROM Gol JOIN Igrac ON Gol.StrelacID = Igrac.ID WHERE MecID = Mec.ID AND Igrac.KlubID = Prvi.ID) AS Golovi1, 
(SELECT COUNT(*) FROM Gol JOIN Igrac ON Gol.StrelacID = Igrac.ID WHERE MecID = Mec.ID AND Igrac.KlubID = Drugi.ID) AS Golovi2, 
Drugi.Naziv AS Klub2, Mec.Datum, Sezona.Naziv
FROM Mec JOIN Klub Prvi ON Mec.Klub1ID = Prvi.ID 
JOIN Klub Drugi ON Mec.Klub2ID = Drugi.ID 
JOIN Sezona ON Mec.SezonaID = Sezona.ID;
/*
SELECT * FROM MecPogled;
DROP VIEW MecPogled;
*/
/*
Store Procedure
*/
/*
Korisnik
*/
GO
CREATE PROCEDURE Dodaj_Korisnik @Imejl NVARCHAR(20), @Lozinka NVARCHAR(20), @Uloga INT
AS
BEGIN
INSERT INTO Korisnik(Imejl, Lozinka, Uloga)
VALUES(@Imejl, @Lozinka, @Uloga)
END
GO

GO
CREATE PROCEDURE Obrisi_Korinsik @ID INT
AS
BEGIN
DELETE FROM Korisnik
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Korisnik @ID INT, @Imejl NVARCHAR(20), @Lozinka NVARCHAR(20), @Uloga INT
AS
BEGIN
UPDATE Korisnik
SET Imejl = @Imejl, Lozinka = @Lozinka, Uloga = @Uloga
WHERE ID = @ID
END
GO

/*
Sezona
*/

GO
CREATE PROCEDURE Dodaj_Sezona @Naziv NVARCHAR(20)
AS
BEGIN
INSERT INTO Sezona(Naziv)
VALUES(@Naziv)
END
GO

GO
CREATE PROCEDURE Obrisi_Sezona @ID INT
AS
BEGIN
DELETE FROM Sezona
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Sezona @ID INT, @Naziv NVARCHAR(20)
AS
BEGIN
UPDATE Sezona
SET Naziv = @Naziv
WHERE ID = @ID
END
GO

/*
Klub
*/

GO
CREATE PROCEDURE Dodaj_Klub @Naziv NVARCHAR(20)
AS
BEGIN
INSERT INTO Klub(Naziv)
VALUES(@Naziv)
END
GO

GO
CREATE PROCEDURE Obrisi_Klub @ID INT
AS
BEGIN
DELETE FROM Klub
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Klub @ID INT, @Naziv NVARCHAR(20)
AS
BEGIN
UPDATE Klub
SET Naziv = @Naziv
WHERE ID = @ID
END
GO

/*
Igrac
*/

GO
CREATE PROCEDURE Dodaj_Igrac @Ime NVARCHAR(20), @Prezime NVARCHAR(20), @KlubID INT
AS
BEGIN
INSERT INTO Igrac(Ime, Prezime, KlubID)
VALUES(@Ime, @Prezime, @KlubID)
END
GO

GO
CREATE PROCEDURE Obrisi_Igrac @ID INT
AS
BEGIN
DELETE FROM Igrac
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Igrac @ID INT, @Ime NVARCHAR(20), @Prezime NVARCHAR(20), @KlubID INT
AS
BEGIN
UPDATE Igrac
SET Ime = @Ime, Prezime = @Prezime, KlubID = @KlubID
WHERE ID = @ID
END
GO

/*
Mec
*/

GO
CREATE PROCEDURE Dodaj_Mec @Klub1ID INT, @Klub2ID INT, @Datum DATE, @SezonaID INT
AS
BEGIN
INSERT INTO Mec(Klub1ID, Klub2ID, Datum, SezonaID)
VALUES(@Klub1ID, @Klub2ID, @Datum, @SezonaID)
END
GO

GO
CREATE PROCEDURE Obrisi_Mec @ID INT
AS
BEGIN
DELETE FROM Mec
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Mec @ID INT, @Klub1ID INT, @Klub2ID INT, @Datum DATE, @SezonaID INT
AS
BEGIN
UPDATE Mec
SET Klub1ID = @Klub1ID, Klub2ID = @Klub2ID, Datum = @Datum, SezonaID = @SezonaID
WHERE ID = @ID
END
GO

/*
Gol
*/

GO
CREATE PROCEDURE Dodaj_Gol @StrelacID INT, @AsistiraoID INT, @MecID INT
AS
BEGIN
INSERT INTO Gol(StrelacID, AsistiraoID, MecID)
VALUES(@StrelacID, @AsistiraoID, @MecID)
END
GO

GO
CREATE PROCEDURE Obrisi_Gol @ID INT
AS
BEGIN
DELETE FROM Gol
WHERE ID = @ID
END
GO

GO
CREATE PROCEDURE Izmeni_Gol @ID INT, @StrelacID INT, @AsistiraoID INT, @MecID INT
AS
BEGIN
UPDATE Gol
SET StrelacID = @StrelacID, AsistiraoID = @AsistiraoID, MecID = @MecID
WHERE ID = @ID
END
GO

/*
Popunjavanje
*/

GO
EXEC Dodaj_Korisnik "admin@liga.com", "123", 1
EXEC Dodaj_Korisnik "korisnik@liga.com", "123", 2 

EXEC Dodaj_Sezona '2020-21'
EXEC Dodaj_Sezona '2021-22'

EXEC Dodaj_Klub 'Milan'
EXEC Dodaj_Klub 'Inter'
EXEC Dodaj_Klub 'Napoli'
EXEC Dodaj_Klub 'Juventus'
EXEC Dodaj_Klub 'Lacio'

EXEC Dodaj_Igrac 'Zlatan', 'Ibrahimovic', 1
EXEC Dodaj_Igrac 'Dusan', 'Vlahovic', 4
EXEC Dodaj_Igrac 'Ciro', 'Imobile', 5
EXEC Dodaj_Igrac 'Paulo', 'Dibala', 4
EXEC Dodaj_Igrac 'Lautaro', 'Martinez', 2
EXEC Dodaj_Igrac 'Viktor', 'Osimhen', 3
EXEC Dodaj_Igrac 'Sergej', 'Milinkovic Savic', 5

EXEC Dodaj_Mec 4, 5, '2022-05-10', 2
EXEC Dodaj_Mec 1, 5, '2022-05-12', 2

EXEC Dodaj_Gol 2, 4, 1
EXEC Dodaj_Gol 3, 7, 2
GO