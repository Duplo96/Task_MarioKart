CREATE TABLE Squadra(
	squadraID INT PRIMARY KEY IDENTITY (1,1),
	nomeUtente VARCHAR(250) NOT NULL,
	nomeSquadra VARCHAR(250) NOT NULL,
	crediti INT DEFAULT 10,
	codice VARCHAR (250) DEFAULT NEWID()
);

CREATE TABLE Personaggi(
	personaggioID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250) NOT NULL,
	costo INT NOT NULL,
	codice VARCHAR (250) DEFAULT NEWID(),
	categoria VARCHAR (50) NOT NULL,
	img VARCHAR (300),
	squadraRIF INT,
	FOREIGN KEY (squadraRIF) REFERENCES Squadra(squadraID),
	UNIQUE(codice, squadraRIF, categoria)
);

use Task_MarioKart

SELECT * FROM Personaggi
SELECT * FROM Squadra