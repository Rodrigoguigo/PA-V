GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelUsuario')
	DROP PROCEDURE SP_SelUsuario

GO

CREATE PROCEDURE SP_SelUsuario
	@LoginEmail VARCHAR(255)
AS
BEGIN
	SELECT UsuarioID, LoginName, Email, Senha FROM USUARIO WHERE LoginName = @LoginEmail OR Email = @LoginEmail
END

GO