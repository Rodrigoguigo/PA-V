CREATE TABLE USUARIO
(
	UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
	LoginName VARCHAR(255),
	Email VARCHAR(255),
	Senha CHAR(32),
	TipoLogin INT
)

CREATE TABLE PROJETO
(
	ProjetoID INT NOT NULL,
	Titulo VARCHAR(255) NOT NULL,
	UsuarioID INT NOT NULL,
	ProjetoPai INT NULL,

	CONSTRAINT PK_Projeto PRIMARY KEY (UsuarioID, ProjetoID),
	CONSTRAINT FK_UsuarioProjeto FOREIGN KEY (UsuarioID) REFERENCES USUARIO,
	CONSTRAINT FK_SubProjeto FOREIGN KEY (UsuarioID, ProjetoPai) REFERENCES PROJETO
)

CREATE TABLE TAREFA
(
	TarefaID INT IDENTITY(1,1) PRIMARY KEY,
	Titulo VARCHAR(255) NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
	DataEntrega DATE NOT NULL,
	ProjetoID INT NOT NULL,
	UsuarioID INT NOT NULL,

	CONSTRAINT FK_ProjetoTarefa FOREIGN KEY (UsuarioID, ProjetoID) REFERENCES PROJETO
)

CREATE TABLE NOTIFICACAO
(
	NotificacaoID INT IDENTITY(1,1) PRIMARY KEY,
	DataHora DATETIME NOT NULL,
	Mensagem VARCHAR(255) NULL,
	TarefaID INT NOT NULL,

	CONSTRAINT FK_TarefaNotificadao FOREIGN KEY (TarefaID) REFERENCES TAREFA
)

CREATE TABLE ARQUIVO
(
	ArquivoID INT IDENTITY(1,1) PRIMARY KEY,
	NomeArquivo VARCHAR(100) NOT NULL,
	Arquivo VARBINARY(MAX) NOT NULL,
	Descricao VARCHAR(255) NULL,
	TarefaID INT NOT NULL,

	CONSTRAINT FK_TarefaArquivo FOREIGN KEY (TarefaID) REFERENCES TAREFA
)