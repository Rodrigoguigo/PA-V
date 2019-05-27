GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelProjetoUsuario')
	DROP PROCEDURE SP_SelProjetoUsuario

GO

CREATE PROCEDURE SP_SelProjetoUsuario
	@UsuarioID INT,
	@ConsultaFilhos CHAR NULL
AS
BEGIN
	SELECT ProjetoID, Titulo, ProjetoPai FROM PROJETO 
	WHERE UsuarioID = @UsuarioID AND (ISNULL(@ConsultaFilhos, 'S') = 'S' OR ProjetoPai IS NULL)
END

GO