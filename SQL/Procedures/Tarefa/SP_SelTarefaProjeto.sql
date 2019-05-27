GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_SelTarefaProjeto')
	DROP PROCEDURE SP_SelTarefaProjeto

GO

CREATE PROCEDURE SP_SelTarefaProjeto
	@ProjetoID INT,
	@UsuarioID INT
AS
BEGIN
	SELECT TarefaID, Titulo, Descricao, DataEntrega FROM TAREFA
	WHERE ProjetoID = @ProjetoID AND UsuarioID = @UsuarioID
END

GO