GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncTarefa')
	DROP PROCEDURE SP_IncTarefa

GO

CREATE PROCEDURE SP_IncTarefa
	@Titulo VARCHAR(255),
	@Descricao VARCHAR(255),
	@DataEntrega DATE,
	@ProjetoID INT,
	@UsuarioID INT
AS
BEGIN
	INSERT INTO TAREFA (Titulo, Descricao, DataEntrega, ProjetoID, UsuarioID) 
	VALUES (@Titulo, @Descricao, @DataEntrega, @ProjetoID, @UsuarioID)
END

GO