GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncNotificacao')
	DROP PROCEDURE SP_IncNotificacao

GO

CREATE PROCEDURE SP_IncNotificacao
	@DataHora DATETIME,
	@Mensagem VARCHAR(255),
	@TarefaID INT
AS
BEGIN
	INSERT INTO NOTIFICACAO (DataHora, Mensagem, TarefaID) 
	VALUES (@DataHora, @Mensagem, @TarefaID)
END

GO