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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_IncProjeto')
	DROP PROCEDURE SP_IncProjeto

GO

CREATE PROCEDURE SP_IncProjeto
	@Titulo VARCHAR(255),
	@UsuarioID INT,
	@ProjetoPai INT NULL
AS
BEGIN
	INSERT INTO PROJETO (Titulo, UsuarioID, ProjetoPai)
	VALUES (@Titulo, @UsuarioID, @ProjetoPai)
END

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