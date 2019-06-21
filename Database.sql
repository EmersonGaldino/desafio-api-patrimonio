IF NOT EXISTS (SELECT name, xtype FROM sysobjects WHERE name='Marca' AND xtype='U')
	CREATE TABLE Marca (
		MarcaId INT NOT NULL IDENTITY(1,1),
		Nome VARCHAR(64) NOT NULL UNIQUE,

		CONSTRAINT PK_Marca PRIMARY KEY(MarcaId)
	)
GO

IF NOT EXISTS (SELECT name, xtype FROM sysobjects WHERE name='Patrimonio' AND xtype='U')
	CREATE TABLE Patrimonio (
		NroTombo INT NOT NULL IDENTITY(1,1),
		MarcaId INT NOT NULL,
		Nome VARCHAR(64) NOT NULL,
		Descricao VARCHAR(256)

		CONSTRAINT PK_Patrimonio PRIMARY KEY(NroTombo),
		CONSTRAINT FK_Patrimonio_MarcaId_Marca_MarcaId FOREIGN KEY(MarcaId) REFERENCES Marca(MarcaId)
	)