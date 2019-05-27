GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelTarefa')
	DROP PROCEDURE SP_SelTarefa

GO

CREATE PROCEDURE SP_SelTarefa
	@TarefaID INT,
	@UsuarioID INT
AS
BEGIN
	SELECT TarefaID, Titulo, Descricao, DataEntrega, ProjetoID FROM TAREFA
	WHERE TarefaID = @TarefaID AND UsuarioID = @UsuarioID
END

GO