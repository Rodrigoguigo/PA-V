CREATE TRIGGER TR_Projeto_Insert
ON PROJETO
INSTEAD OF INSERT
AS
	DECLARE 
		@ProjID INT,
		@UsuID INT,
		@Titulo VARCHAR(255),
		@ProjPai INT

SELECT @UsuID = UsuarioID, @Titulo = Titulo, @ProjPai = ProjetoPai FROM INSERTED

IF NOT EXISTS (SELECT * FROM PROJETO WHERE UsuarioID = @UsuID)
	SET @ProjID = 1
ELSE
	SET @ProjID = (SELECT MAX(P.ProjetoID)+1
					FROM PROJETO P
					WHERE P.UsuarioID = @UsuID)

	INSERT INTO PROJETO (ProjetoID, Titulo, UsuarioID, ProjetoPai)
				VALUES (@ProjID, @Titulo, @UsuID, @ProjPai)