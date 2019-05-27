GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncProjeto')
	DROP PROCEDURE SP_IncProjeto

GO

CREATE PROCEDURE SP_IncProjeto
	@Titulo VARCHAR(255),
	@UsuarioID INT,
	@ProjetoPai INT NULL
AS
BEGIN
	INSERT INTO PROJETO (Titulo, UsuarioID, ProjetoPai)
	VALUES (@Titulo, @UsuarioID, @ProjetoPai)
END

GO