GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncUsuario')
	DROP PROCEDURE SP_IncUsuario

GO

CREATE PROCEDURE SP_IncUsuario
	@Login VARCHAR(255),
	@Senha CHAR(32),
	@TpLogin INT
AS
BEGIN
	INSERT INTO USUARIO (LoginName, Senha, TipoLogin) 
	VALUES (@Login, @Senha, @TpLogin)
END

GO