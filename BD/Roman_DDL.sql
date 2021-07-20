CREATE DATABASE RomanNovo;
GO
USE RomanNovo;
CREATE TABLE tipoUsuario(
	idTipo	INT PRIMARY KEY IDENTITY,
	tipo	VARCHAR(200) NOT NULL,
);
GO
CREATE TABLE usuario(
	idUsuario	INT PRIMARY KEY IDENTITY,
	usuario		VARCHAR(200) UNIQUE NOT NULL,
	senha		VARCHAR(200) NOT NULL,
	idTipo		INT FOREIGN KEY REFERENCES tipoUsuario(idTipo)
);
GO
CREATE TABLE tema(
	idTema		INT PRIMARY KEY IDENTITY,
	tema		VARCHAR(200) NOT NULL UNIQUE
);
GO
CREATE TABLE projeto(
	idProjeto	INT PRIMARY KEY IDENTITY,
	projeto		VARCHAR(200) NOT NULL UNIQUE,
	idTema		INT FOREIGN KEY REFERENCES tema(idTema),
	idUsuario	INT FOREIGN KEY REFERENCES usuario(idUsuario),
	descricao	VARCHAR(900) NOT NULL
);
GO