CREATE TABLE Marca (
	MarcaId INT NOT NULL,
	Nome VARCHAR(64) NOT NULL,

	CONSTRAINT(PK_Marca PRIMARY KEY(MarcaId))
)

CREATE TABLE Patrimonio (
	PatrimonioId INT NOT NULL,
	MarcaId INT NOT NULL,
	Nome VARCHAR(64) NOT NULL,
	Descricao VARCHAR(256),
	NroTombo INT,

	CONSTRAINT(PK_Patrimonio PRIMARY KEY(PatrimonioId)),
	CONSTRAINT(FK_Patrimonio_MarcaId_Marca_MarcaId FOREIGN KEY(MarcaId) REFERENCES Marca(MarcaId))
)