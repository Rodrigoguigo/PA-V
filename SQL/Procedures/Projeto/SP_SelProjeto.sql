GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelProjeto')
	DROP PROCEDURE SP_SelProjeto

GO

CREATE PROCEDURE SP_SelProjeto
	@ProjetoId INT,
	@UsuarioId INT
AS
BEGIN
	SELECT ProjetoID, Titulo, ProjetoPai FROM PROJETO 
	WHERE ProjetoID = @ProjetoId AND UsuarioID = @UsuarioId
END

GO