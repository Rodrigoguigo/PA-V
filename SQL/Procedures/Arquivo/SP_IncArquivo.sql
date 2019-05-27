GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncArquivo')
	DROP PROCEDURE SP_IncArquivo

GO

CREATE PROCEDURE SP_IncArquivo
	@NomeArquivo VARCHAR(100),
	@Arquivo VARBINARY(MAX),
	@Descricao VARCHAR(255),
	@TarefaID INT
AS
BEGIN
	INSERT INTO ARQUIVO (NomeArquivo, Arquivo, Descricao, TarefaID) 
	VALUES (@NomeArquivo, @Arquivo, @Descricao, @TarefaID)
END

GO