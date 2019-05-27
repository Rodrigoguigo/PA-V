GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelProjetosFilhos')
	DROP PROCEDURE SP_SelProjetosFilhos

GO

CREATE PROCEDURE SP_SelProjetosFilhos
	@UsuarioID INT,
	@ProjetoPai INT
AS
BEGIN
	SELECT ProjetoID, Titulo, ProjetoPai FROM PROJETO 
	WHERE UsuarioID = @UsuarioID AND ProjetoPai = @ProjetoPai
END

GO