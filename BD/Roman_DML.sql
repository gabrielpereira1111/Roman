USE RomanNovo
GO

INSERT INTO tipoUsuario (tipo)
VALUES					('Professor'),
					    ('Administrador')
GO

INSERT INTO usuario (usuario, senha, idTipo)
VALUES				('Administrador','ADMIN',2),
					('Henrique','Henrique',1),
					('Rafael','Rafael',1)
GO

INSERT INTO tema (tema)
VALUES			 ('Gestão'),
				 ('HQs')
GO

INSERT INTO projeto (projeto, idTema, idUsuario, descricao)
VALUES				('Controle de Estoque', 1, 2, 'Projeto de Controle de Estoque'),
					('Listagem de Personagens', 2, 3, 'Projeto de Listagem de Personagens')
GO
