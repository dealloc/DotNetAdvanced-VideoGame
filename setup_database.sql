DROP TABLE IF EXISTS Inventory;
DROP TABLE IF EXISTS Weapons;
DROP TABLE IF EXISTS Players;

CREATE TABLE Players (
	Id INT NOT NULL IDENTITY,
	Username NVARCHAR(50) NOT NULL,
	Health FLOAT NOT NULL,
	Class NVARCHAR(10) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE Weapons (
	Id INT NOT NULL IDENTITY,
	Class NVARCHAR(250) NOT NULL,
	Damage INT NOT NULL,
	PlayerId INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (PlayerId) REFERENCES Players(Id)
);

CREATE TABLE Inventory (
	Id INT NOT NULL IDENTITY,
	Class NVARCHAR(250) NOT NULL,
	PlayerId INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (PlayerId) REFERENCES Players(Id)
);