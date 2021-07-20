USE RomanNovo

SELECT * FROM tema
SELECT * FROM projeto
SELECT * FROM usuario
SELECT * FROM tipoUsuario

SELECT * FROM usuario
INNER JOIN tipoUsuario
ON usuario.idTipo = tipoUsuario.idTipo
INNER JOIN projeto
ON usuario.idUsuario = projeto.idUsuario