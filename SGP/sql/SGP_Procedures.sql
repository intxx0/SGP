USE [SGP]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar dados do usuário
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_USUARIO_SAVE]
	@USU_CODIGO			INT = NULL,
	@USU_GRUPO			INT,
	@USU_UNIDADE		INT,
	@USU_NOME			VARCHAR(80),
	@USU_EMAIL			VARCHAR(170),
	@USU_LOGIN			VARCHAR(50),	
	@USU_SENHA			VARCHAR(32),	
	@USU_OBSERVACOES	VARCHAR(255),	
	@USU_STATUS			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(USU_UNIDADE INT, USU_GRUPO INT, USU_NOME VARCHAR, 
								USU_EMAIL VARCHAR, USU_LOGIN VARCHAR, USU_SENHA VARCHAR,
								USU_OBSERVACOES VARCHAR, USU_STATUS INT)
								
		IF(@USU_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_USUARIOS (USU_UNIDADE, USU_GRUPO, USU_NOME, USU_EMAIL, USU_LOGIN, USU_SENHA, USU_OBSERVACOES, USU_STATUS) 
						VALUES  (@USU_UNIDADE, @USU_GRUPO, @USU_NOME, @USU_EMAIL, @USU_LOGIN, HASHBYTES('MD5', @USU_SENHA), @USU_OBSERVACOES, @USU_STATUS)

				SELECT @@identity AS 'USU_CODIGO'

			END
		ELSE
			BEGIN
				UPDATE TBL_USUARIOS
				SET USU_UNIDADE = @USU_UNIDADE, USU_NOME = @USU_NOME, USU_EMAIL = @USU_EMAIL, USU_LOGIN = @USU_LOGIN, 
					USU_SENHA = HASHBYTES('MD5', @USU_SENHA), USU_OBSERVACOES = @USU_OBSERVACOES, USU_STATUS = @USU_STATUS
				WHERE USU_CODIGO = @USU_CODIGO
			END
	END

END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para autenticação de usuário
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_USUARIO_AUTH] 

	@USU_LOGIN	VARCHAR(50) = NULL,
	@USU_SENHA	VARCHAR(50) = NULL
	
AS
BEGIN

	SET NOCOUNT ON
	
	BEGIN

		SELECT T1.*, T2.UNI_NOME AS UNIDADE
		FROM TBL_USUARIOS T1
		INNER JOIN TBL_UNIDADES T2 ON T1.USU_UNIDADE = T2.UNI_CODIGO 
		WHERE USU_LOGIN = @USU_LOGIN AND USU_SENHA = HASHBYTES('MD5', @USU_SENHA)		
	
	END
	
END
GO





--------------------------------------------------------------------------------------------
-- Procedimento para busca de usuário
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_USUARIOS_SEARCH] 

	@SEARCH		VARCHAR(80) = NULL,
	@USU_CODIGO	INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*, T2.UNI_NOME AS UNIDADE, T3.GRU_NOME AS GRUPO
		FROM TBL_USUARIOS T1 
		INNER JOIN TBL_UNIDADES T2 ON T1.USU_UNIDADE = T2.UNI_CODIGO 
		INNER JOIN TBL_GRUPOS T3 ON T1.USU_GRUPO = T3.GRU_CODIGO 
		WHERE (USU_NOME LIKE @SEARCH OR USU_EMAIL LIKE @SEARCH OR USU_LOGIN LIKE @SEARCH) AND USU_STATUS >= 0 
		ORDER BY USU_NOME
	END
	ELSE IF(NOT @USU_CODIGO IS NULL)
	BEGIN
		SELECT T1.*, T2.UNI_NOME AS UNIDADE, T3.GRU_NOME AS GRUPO
		FROM TBL_USUARIOS T1 
		INNER JOIN TBL_UNIDADES T2 ON T1.USU_UNIDADE = T2.UNI_CODIGO 
		INNER JOIN TBL_GRUPOS T3 ON T1.USU_GRUPO = T3.GRU_CODIGO 
		WHERE T1.USU_CODIGO = @USU_CODIGO AND T1.USU_STATUS >= 0
		ORDER BY T1.USU_NOME
	END
	ELSE
	BEGIN
		SELECT T1.*, T2.UNI_NOME AS UNIDADE, T3.GRU_NOME AS GRUPO
		FROM TBL_USUARIOS T1 
		INNER JOIN TBL_UNIDADES T2 ON T1.USU_UNIDADE = T2.UNI_CODIGO 
		INNER JOIN TBL_GRUPOS T3 ON T1.USU_GRUPO = T3.GRU_CODIGO 
		WHERE T1.USU_STATUS >= 0
		ORDER BY USU_NOME
	END
	
END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para busca da usuario por login
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_USUARIO_BY_LOGIN] 
	@USU_LOGIN		VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_USUARIOS WHERE USU_LOGIN = @USU_LOGIN
	
END
GO









--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de usuario
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_USUARIO] 
	@USU_CODIGO		INT
AS
BEGIN

	-- DELETE FROM TBL_USUARIOS WHERE USU_CODIGO = @USU_CODIGO
	UPDATE TBL_USUARIOS SET USU_STATUS = -2 WHERE USU_CODIGO = @USU_CODIGO
	
END
GO






--------------------------------------------------------------------------------------------
-- Procedimento para registro de acesso de usuário
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_USUARIO_ACESSO] 

	@USU_CODIGO	INT
	
AS
BEGIN

	SET NOCOUNT ON
	
	BEGIN

		INSERT INTO TBL_ACESSOS (ACE_USUARIO) VALUES (@USU_CODIGO)
	
	END
	
END
GO





--------------------------------------------------------------------------------------------
-- Procedimento para busca de unidades
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_UNIDADES] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_UNIDADES ORDER BY UNI_NOME
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca da unidade por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_UNIDADE_BY_NOME] 
	@NOME		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_UNIDADES WHERE UNI_NOME = @NOME
	
END
GO





















--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar dados do veículo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_VEICULO_SAVE]
	@VEI_CODIGO			INT = NULL,
	@VEI_TIPO			INT,
	@VEI_NOME			VARCHAR(50),
	@VEI_PLACA			VARCHAR(7),
	@VEI_TARA			INT,	
	@VEI_STATUS			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(VEI_TIPO INT, VEI_NOME VARCHAR, 
								VEI_PLACA VARCHAR, VEI_TARA INT, VEI_STATUS INT)
								
		IF(@VEI_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_VEICULOS (VEI_NOME, VEI_TIPO, VEI_PLACA, VEI_TARA, VEI_STATUS) 
						VALUES  (@VEI_NOME, @VEI_TIPO, @VEI_PLACA, @VEI_TARA, @VEI_STATUS)

				SELECT @@identity AS 'VEI_CODIGO'

			END
		ELSE
			BEGIN
				UPDATE TBL_VEICULOS
				SET VEI_TIPO = @VEI_TIPO, VEI_NOME = @VEI_NOME, VEI_PLACA = @VEI_PLACA, VEI_TARA = @VEI_TARA, VEI_STATUS = @VEI_STATUS
				WHERE VEI_CODIGO = @VEI_CODIGO
			END
	END

END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de veículo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_VEICULOS_SEARCH] 

	@SEARCH		VARCHAR(80) = NULL,
	@VEI_CODIGO	INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*, T2.VET_NOME AS TIPO
		FROM TBL_VEICULOS T1 
		INNER JOIN TBL_VEICULOS_TIPOS T2 ON T1.VEI_TIPO = T2.VET_CODIGO 
		WHERE (VEI_NOME LIKE @SEARCH OR VEI_PLACA LIKE @SEARCH OR VEI_TARA LIKE @SEARCH) AND VEI_STATUS >= 0
		ORDER BY VEI_NOME
	END
	ELSE IF(NOT @VEI_CODIGO IS NULL)
	BEGIN
		SELECT T1.*, T2.VET_NOME AS TIPO
		FROM TBL_VEICULOS T1 
		INNER JOIN TBL_VEICULOS_TIPOS T2 ON T1.VEI_TIPO = T2.VET_CODIGO 
		WHERE T1.VEI_CODIGO = @VEI_CODIGO AND T1.VEI_STATUS >= 0
		ORDER BY T1.VEI_NOME
	END
	ELSE
	BEGIN
		SELECT T1.*, T2.VET_NOME AS TIPO
		FROM TBL_VEICULOS T1 
		INNER JOIN TBL_VEICULOS_TIPOS T2 ON T1.VEI_TIPO = T2.VET_CODIGO 
		WHERE T1.VEI_STATUS >= 0
		ORDER BY VEI_NOME
	END
	
END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para busca da veiculo por placa
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_VEICULO_BY_PLACA] 
	@VEI_PLACA		VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_VEICULOS WHERE VEI_PLACA = @VEI_PLACA
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de veiculo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_VEICULO] 
	@VEI_CODIGO		INT
AS
BEGIN

	-- DELETE FROM TBL_VEICULOS WHERE VEI_CODIGO = @VEI_CODIGO
	UPDATE TBL_VEICULOS SET VEI_STATUS = -2 WHERE VEI_CODIGO = @VEI_CODIGO
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para busca de tipos de veiculos
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_VEICULOS_TIPOS] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_VEICULOS_TIPOS ORDER BY VET_NOME
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca da tipo de veiculo por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_VEICULO_TIPO_BY_NOME] 
	@NOME		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_VEICULOS_TIPOS WHERE VET_NOME = @NOME
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de veículos por tipo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_VEICULOS_BY_TIPO] 

	@TIPO		VARCHAR(50) = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	BEGIN
		SELECT T1.*, T2.VET_NOME AS TIPO
		FROM TBL_VEICULOS T1 
		INNER JOIN TBL_VEICULOS_TIPOS T2 ON T1.VEI_TIPO = T2.VET_CODIGO 
		WHERE T2.VET_NOME = @TIPO 
		ORDER BY VEI_NOME
	END
	
END
GO













--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar dados do emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSOR_SAVE]
	@EMI_CODIGO			INT = NULL,
	@EMI_CIDADE			BIGINT,
	@EMI_NOME_FANTASIA	VARCHAR(80),
	@EMI_RAZAO_SOCIAL	VARCHAR(80),
	@EMI_TIPO_PESSOA	INT,
	@EMI_TIPO_CLIENTE	INT,
	@EMI_CNPJ			VARCHAR(18),
	@EMI_CPF			VARCHAR(14),
	@EMI_IE				VARCHAR(14),
	@EMI_IM				VARCHAR(14),
	@EMI_ENDERECO		VARCHAR(80),
	@EMI_NUMERO			VARCHAR(20),
	@EMI_BAIRRO			VARCHAR(80),
	@EMI_EMAIL			VARCHAR(170),
	@EMI_TELEFONE		VARCHAR(40),
	@EMI_CELULAR		VARCHAR(40),
	@EMI_OBSERVACOES	VARCHAR(255),
	@EMI_STATUS			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(EMI_NOME_FANTASIA VARCHAR, EMI_RAZAO_SOCIAL VARCHAR, EMI_TIPO_PESSOA INT, EMI_TIPO_CLIENTE INT,
							  EMI_CNPJ VARCHAR, EMI_CPF VARCHAR, EMI_IE VARCHAR, EMI_IM VARCHAR, EMI_ENDERECO VARCHAR, 
							  EMI_NUMERO VARCHAR, EMI_BAIRRO VARCHAR, EMI_EMAIL VARCHAR, EMI_TELEFONE VARCHAR, EMI_CELULAR VARCHAR, 
							  EMI_CIDADE VARCHAR, EMI_UF VARCHAR, EMI_STATUS INT)
								
		IF(@EMI_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_EMISSORES (EMI_CIDADE, EMI_NOME_FANTASIA, EMI_RAZAO_SOCIAL, EMI_TIPO_PESSOA, EMI_TIPO_CLIENTE, EMI_CNPJ, EMI_CPF, EMI_IE, EMI_IM, EMI_ENDERECO, EMI_NUMERO, EMI_BAIRRO, EMI_EMAIL, EMI_TELEFONE, EMI_CELULAR, EMI_OBSERVACOES, EMI_STATUS) 
						VALUES  (@EMI_CIDADE, @EMI_NOME_FANTASIA, @EMI_RAZAO_SOCIAL, @EMI_TIPO_PESSOA, @EMI_TIPO_CLIENTE, @EMI_CNPJ, @EMI_CPF, @EMI_IE, @EMI_IM, @EMI_ENDERECO, @EMI_NUMERO, @EMI_BAIRRO, @EMI_EMAIL, @EMI_TELEFONE, @EMI_CELULAR, @EMI_OBSERVACOES, @EMI_STATUS)

				SELECT @@identity AS 'EMI_CODIGO'

			END
		ELSE
			BEGIN
				UPDATE TBL_EMISSORES
				SET EMI_CIDADE = @EMI_CIDADE, EMI_NOME_FANTASIA = @EMI_NOME_FANTASIA, EMI_RAZAO_SOCIAL = @EMI_RAZAO_SOCIAL, EMI_TIPO_PESSOA = @EMI_TIPO_PESSOA, EMI_TIPO_CLIENTE = @EMI_TIPO_CLIENTE, EMI_CNPJ = @EMI_CNPJ, EMI_CPF = @EMI_CPF, EMI_IE = @EMI_IE, EMI_IM = @EMI_IM, EMI_ENDERECO = @EMI_ENDERECO, EMI_NUMERO = @EMI_NUMERO, EMI_BAIRRO = @EMI_BAIRRO, EMI_EMAIL = @EMI_EMAIL, EMI_TELEFONE = @EMI_TELEFONE, EMI_CELULAR = @EMI_CELULAR, EMI_OBSERVACOES = @EMI_OBSERVACOES, EMI_STATUS = @EMI_STATUS
				WHERE EMI_CODIGO = @EMI_CODIGO
			END
	END

END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca do emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSORES_SEARCH] 

	@SEARCH		VARCHAR(80) = NULL,
	@EMI_CODIGO	INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*, T2.CID_NOME AS CIDADE, T2.CID_UF AS UF
		FROM TBL_EMISSORES T1 
		INNER JOIN TBL_CIDADES T2 ON T1.EMI_CIDADE = T2.CID_CODIGO
		WHERE (EMI_NOME_FANTASIA LIKE @SEARCH OR EMI_ENDERECO LIKE @SEARCH OR EMI_BAIRRO LIKE @SEARCH OR T2.CID_NOME LIKE @SEARCH OR T2.CID_UF LIKE @SEARCH) AND EMI_STATUS >= 0
		GROUP BY T1.EMI_CODIGO, T1.EMI_CIDADE, T1.EMI_NOME_FANTASIA, T1.EMI_RAZAO_SOCIAL, T1.EMI_TIPO_PESSOA, T1.EMI_TIPO_CLIENTE, T1.EMI_CNPJ, T1.EMI_CPF, T1.EMI_IE, T1.EMI_IM, T1.EMI_ENDERECO, T1.EMI_NUMERO, T1.EMI_BAIRRO, T1.EMI_EMAIL, T1.EMI_TELEFONE, T1.EMI_CELULAR, T1.EMI_OBSERVACOES, T1.EMI_STATUS, T2.CID_NOME, T2.CID_UF
		ORDER BY T1.EMI_NOME_FANTASIA
	END
	ELSE IF(NOT @EMI_CODIGO IS NULL)
	BEGIN
		SELECT TOP 1 T1.*, T2.CID_NOME AS CIDADE, T2.CID_UF AS UF
		FROM TBL_EMISSORES T1 
		INNER JOIN TBL_CIDADES T2 ON T1.EMI_CIDADE = T2.CID_CODIGO
		WHERE T1.EMI_CODIGO = @EMI_CODIGO AND T1.EMI_STATUS >= 0
	END
	ELSE
	BEGIN
		SELECT T1.*, T2.CID_NOME AS CIDADE, T2.CID_UF AS UF
		FROM TBL_EMISSORES T1 
		INNER JOIN TBL_CIDADES T2 ON T1.EMI_CIDADE = T2.CID_CODIGO
		WHERE T1.EMI_STATUS >= 0
		GROUP BY T1.EMI_CODIGO, T1.EMI_CIDADE, T1.EMI_NOME_FANTASIA, T1.EMI_RAZAO_SOCIAL, T1.EMI_TIPO_PESSOA, T1.EMI_TIPO_CLIENTE, T1.EMI_CNPJ, T1.EMI_CPF, T1.EMI_IE, T1.EMI_IM, T1.EMI_ENDERECO, T1.EMI_NUMERO, T1.EMI_BAIRRO, T1.EMI_EMAIL, T1.EMI_TELEFONE, T1.EMI_CELULAR, T1.EMI_OBSERVACOES, T1.EMI_STATUS, T2.CID_NOME, T2.CID_UF 
		ORDER BY EMI_NOME_FANTASIA
	END
	
END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para busca de emissor pelo nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_EMISSOR_BY_NOME] 
	@EMI_NOME_FANTASIA		VARCHAR(80)
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_EMISSORES WHERE EMI_NOME_FANTASIA = @EMI_NOME_FANTASIA
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_EMISSOR] 
	@EMI_CODIGO		INT
AS
BEGIN

	-- DELETE FROM TBL_EMISSORES WHERE EMI_CODIGO = @EMI_CODIGO
	UPDATE TBL_EMISSORES SET EMI_STATUS = -2 WHERE EMI_CODIGO = @EMI_CODIGO
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de registros de pré-cadastro de emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSORES_FLUSH] 
AS
BEGIN

	DELETE FROM TBL_EMISSORES WHERE EMI_STATUS = -1
	
END
GO

















--------------------------------------------------------------------------------------------
-- Procedimento para busca distinta de estados
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_CIDADES_UF] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT DISTINCT(CID_UF) FROM TBL_CIDADES ORDER BY CID_UF
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de cidades por uf
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_CIDADES_BY_UF] 
	@CID_UF		VARCHAR(2)
AS
BEGIN

	SET NOCOUNT ON
	SELECT CID_CODIGO, CID_NOME FROM TBL_CIDADES WHERE CID_UF = @CID_UF ORDER BY CID_NOME
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de cidade por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_CIDADE_BY_NOME] 
	@CID_NOME		VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON
	SELECT TOP 1 CID_CODIGO, CID_NOME, CID_UF FROM TBL_CIDADES WHERE CID_NOME = @CID_NOME
	
END
GO



































--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar dados do resíduo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_RESIDUO_SAVE]
	@RES_CODIGO			INT = NULL,
	@RES_TIPO			INT,
	@RES_NOME			VARCHAR(50),
	@RES_STATUS			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(RES_TIPO INT, RES_NOME VARCHAR, RES_STATUS INT)
								
		IF(@RES_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_RESIDUOS (RES_NOME, RES_TIPO, RES_STATUS) 
						VALUES  (@RES_NOME, @RES_TIPO, @RES_STATUS)

				SELECT @@identity AS 'RES_CODIGO'

			END
		ELSE
			BEGIN
				UPDATE TBL_RESIDUOS
				SET RES_TIPO = @RES_TIPO, RES_NOME = @RES_NOME, RES_STATUS = @RES_STATUS
				WHERE RES_CODIGO = @RES_CODIGO
			END
	END

END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de resíduo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_RESIDUOS_SEARCH] 

	@SEARCH		VARCHAR(80) = NULL,
	@RES_CODIGO	INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*, T2.RET_NOME AS TIPO
		FROM TBL_RESIDUOS T1 
		INNER JOIN TBL_RESIDUOS_TIPOS T2 ON T1.RES_TIPO = T2.RET_CODIGO 
		WHERE (RES_NOME LIKE @SEARCH OR RET_NOME LIKE @SEARCH) AND RES_STATUS >= 0
		ORDER BY RES_NOME
	END
	ELSE IF(NOT @RES_CODIGO IS NULL)
	BEGIN
		SELECT T1.*, T2.RET_NOME AS TIPO
		FROM TBL_RESIDUOS T1 
		INNER JOIN TBL_RESIDUOS_TIPOS T2 ON T1.RES_TIPO = T2.RET_CODIGO 
		WHERE T1.RES_CODIGO = @RES_CODIGO AND RES_STATUS >= 0
		ORDER BY T1.RES_NOME
	END
	ELSE
	BEGIN
		SELECT T1.*, T2.RET_NOME AS TIPO
		FROM TBL_RESIDUOS T1 
		INNER JOIN TBL_RESIDUOS_TIPOS T2 ON T1.RES_TIPO = T2.RET_CODIGO 
		WHERE T1.RES_STATUS >= 0
		ORDER BY RES_NOME
	END
	
END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para busca da resíduo por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RESIDUO_BY_NOME] 
	@RES_NOME		VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_RESIDUOS WHERE RES_NOME = @RES_NOME
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para exclusão de resíduo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_RESIDUO] 
	@RES_CODIGO		INT
AS
BEGIN

	-- DELETE FROM TBL_RESIDUOS WHERE RES_CODIGO = @RES_CODIGO
	UPDATE TBL_RESIDUOS SET RES_STATUS = -2 WHERE RES_CODIGO = @RES_CODIGO
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para busca de tipos de resíduos
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RESIDUOS_TIPOS] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_RESIDUOS_TIPOS ORDER BY RET_NOME
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca da tipo de resíduo por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RESIDUO_TIPO_BY_NOME] 
	@NOME		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_RESIDUOS_TIPOS WHERE RET_NOME = @NOME
	
END
GO















--------------------------------------------------------------------------------------------
-- Procedimento para busca de veículos de emissores pela placa
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_EMISSOR_VEICULO_BY_PLACA] 
	@EMI_CODIGO		INT = NULL, 
	@PLACA			VARCHAR(20) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT T1.*
	FROM REL_EMISSORES_VEICULOS T1 
	INNER JOIN TBL_VEICULOS T2 ON T1.EMV_VEICULO = T2.VEI_CODIGO 
	WHERE T1.EMV_EMISSOR = @EMI_CODIGO AND T2.VEI_PLACA = @PLACA
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para inserir associação de veículo com emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSOR_VEICULO_SAVE]
	@EMI_CODIGO			INT,
	@VEI_CODIGO			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(EMI_CODIGO INT, VEI_CODIGO INT)
								
		INSERT INTO REL_EMISSORES_VEICULOS (EMV_EMISSOR, EMV_VEICULO) 
				VALUES  (@EMI_CODIGO, @VEI_CODIGO)

		SELECT @@identity AS 'EMV_CODIGO'

	END

END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca do veículos de emissores
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_EMISSORES_VEICULOS] 

	@EMI_CODIGO	INT
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.EMV_CODIGO, T3.VEI_NOME AS VEICULO, T3.VEI_PLACA AS PLACA, T4.VET_NOME AS TIPO
	FROM REL_EMISSORES_VEICULOS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.EMV_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_VEICULOS T3 ON T1.EMV_VEICULO = T3.VEI_CODIGO
	INNER JOIN TBL_VEICULOS_TIPOS T4 ON T3.VEI_TIPO = T4.VET_CODIGO
	WHERE T2.EMI_CODIGO = @EMI_CODIGO
	GROUP BY T1.EMV_CODIGO, T3.VEI_NOME, T3.VEI_PLACA, T4.VET_NOME
	ORDER BY T3.VEI_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca dos veículos de emissores
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSORES_VEICULOS_SEARCH] 

	@EMI_CODIGO	INT,
	@SEARCH		VARCHAR(80)
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.EMV_CODIGO, T3.VEI_NOME AS VEICULO, T3.VEI_PLACA AS PLACA, T4.VET_NOME AS TIPO
	FROM REL_EMISSORES_VEICULOS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.EMV_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_VEICULOS T3 ON T1.EMV_VEICULO = T3.VEI_CODIGO
	INNER JOIN TBL_VEICULOS_TIPOS T4 ON T3.VEI_TIPO = T4.VET_CODIGO
	WHERE T2.EMI_CODIGO = @EMI_CODIGO AND ( T3.VEI_NOME LIKE @SEARCH OR T3.VEI_PLACA LIKE @SEARCH ) 
	GROUP BY T1.EMV_CODIGO, T3.VEI_NOME, T3.VEI_PLACA, T4.VET_NOME
	ORDER BY T3.VEI_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para exclusão de veículo de emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_EMISSOR_VEICULO] 
	@EMV_CODIGO		INT
AS
BEGIN

	DELETE FROM REL_EMISSORES_VEICULOS WHERE EMV_CODIGO = @EMV_CODIGO
	
END
GO
















--------------------------------------------------------------------------------------------
-- Procedimento para busca dos resíduos de emissores
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSORES_RESIDUOS_SEARCH] 

	@EMI_CODIGO	INT,
	@SEARCH		VARCHAR(80)
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.EMR_CODIGO, T3.RES_NOME AS RESIDUO, T4.RET_NOME AS TIPO
	FROM REL_EMISSORES_RESIDUOS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.EMR_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_RESIDUOS T3 ON T1.EMR_RESIDUO = T3.RES_CODIGO
	INNER JOIN TBL_RESIDUOS_TIPOS T4 ON T3.RES_TIPO = T4.RET_CODIGO
	WHERE T2.EMI_CODIGO = @EMI_CODIGO AND ( T3.RES_NOME LIKE @SEARCH ) 
	GROUP BY T1.EMR_CODIGO, T3.RES_NOME, T4.RET_NOME
	ORDER BY T3.RES_NOME
	
END
GO














--------------------------------------------------------------------------------------------
-- Procedimento para busca de resíduos por nome do tipo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RESIDUOS_BY_NOME_TIPO] 
	@NOME		VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON
	SELECT T1.* 
	FROM TBL_RESIDUOS T1
	INNER JOIN TBL_RESIDUOS_TIPOS T2 ON T1.RES_TIPO = T2.RET_CODIGO
	WHERE T2.RET_NOME = @NOME AND T1.RES_STATUS >= 0
	ORDER BY T1.RES_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de resíeduos de emissores pelo nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_EMISSOR_RESIDUO_BY_NOME] 
	@EMI_CODIGO		INT = NULL, 
	@NOME			VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT T1.*
	FROM REL_EMISSORES_RESIDUOS T1 
	INNER JOIN TBL_RESIDUOS T2 ON T1.EMR_RESIDUO = T2.RES_CODIGO 
	WHERE T1.EMR_EMISSOR = @EMI_CODIGO AND T2.RES_NOME = @NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para inserir associação de resíduo com emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_EMISSOR_RESIDUO_SAVE]
	@EMI_CODIGO			INT,
	@RES_CODIGO			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(EMI_CODIGO INT, RES_CODIGO INT)
								
		INSERT INTO REL_EMISSORES_RESIDUOS (EMR_EMISSOR, EMR_RESIDUO) 
				VALUES  (@EMI_CODIGO, @RES_CODIGO)

		SELECT @@identity AS 'EMR_CODIGO'

	END

END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca do resíduos de emissores
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_EMISSORES_RESIDUOS] 

	@EMI_CODIGO	INT
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.EMR_CODIGO, T3.RES_NOME AS RESIDUO, T4.RET_NOME AS TIPO
	FROM REL_EMISSORES_RESIDUOS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.EMR_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_RESIDUOS T3 ON T1.EMR_RESIDUO = T3.RES_CODIGO
	INNER JOIN TBL_RESIDUOS_TIPOS T4 ON T3.RES_TIPO = T4.RET_CODIGO
	WHERE T2.EMI_CODIGO = @EMI_CODIGO
	GROUP BY T1.EMR_CODIGO, T3.RES_NOME, T4.RET_NOME
	ORDER BY T3.RES_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para exclusão de resíduo de emissor
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_EMISSOR_RESIDUO] 
	@EMR_CODIGO		INT
AS
BEGIN

	DELETE FROM REL_EMISSORES_RESIDUOS WHERE EMR_CODIGO = @EMR_CODIGO
	
END
GO







--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar dados de pesagem
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_PESAGEM_SAVE]
	@PES_CODIGO			INT = NULL,
	@PES_UNIDADE		INT,
	@PES_USUARIO		INT,
	@PES_VEICULO		INT,
	@PES_RESIDUO		INT,
	@PES_EMISSOR		INT,
	@PES_PESO_BRUTO		REAL,
	@PES_PESO_LIQUIDO	REAL,
	@PES_PESO_TARA		REAL,
	@PES_DATA_ENTRADA	DATETIME,
	@PES_DATA_SAIDA		DATETIME,
	@PES_OBSERVACOES	TEXT, 
	@PES_STATUS			INT, 
	@PES_CHECKSUM		VARCHAR(32)
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
	
		DECLARE @CAMPOS TABLE(PES_CODIGO INT, PES_UNIDADE INT, PES_USUARIO INT, PES_VEICULO INT, PES_RESIDUO INT, PES_EMISSOR INT, 
							  PES_PESO_BRUTO REAL, PES_PESO_LIQUIDO REAL, PES_PESO_TARA REAL, PES_DATA_ENTRADA DATETIME, PES_DATA_SAIDA DATETIME, PES_OBSERVACOES TEXT, PES_STATUS INT, PES_CHECKSUM VARCHAR)
								
		IF(@PES_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_PESAGENS (PES_UNIDADE, PES_USUARIO, PES_VEICULO, PES_RESIDUO, PES_EMISSOR, PES_PESO_BRUTO, PES_PESO_LIQUIDO, PES_PESO_TARA, PES_DATA_ENTRADA, PES_DATA_SAIDA, PES_OBSERVACOES, PES_STATUS, PES_CHECKSUM) 
						VALUES  (@PES_UNIDADE, @PES_USUARIO, @PES_VEICULO, @PES_RESIDUO, @PES_EMISSOR, @PES_PESO_BRUTO, @PES_PESO_LIQUIDO, @PES_PESO_TARA, @PES_DATA_ENTRADA, @PES_DATA_SAIDA, @PES_OBSERVACOES, @PES_STATUS, @PES_CHECKSUM)
						
				SELECT @@identity AS 'PES_CODIGO'

			END
		ELSE
			BEGIN
				
				UPDATE TBL_PESAGENS
				SET PES_UNIDADE = @PES_UNIDADE, PES_USUARIO = @PES_USUARIO, PES_VEICULO = @PES_VEICULO, PES_RESIDUO = @PES_RESIDUO, PES_EMISSOR = @PES_EMISSOR, PES_PESO_BRUTO = @PES_PESO_BRUTO, PES_PESO_LIQUIDO = @PES_PESO_LIQUIDO, PES_PESO_TARA = @PES_PESO_TARA, PES_DATA_SAIDA = @PES_DATA_SAIDA, PES_OBSERVACOES = @PES_OBSERVACOES, PES_STATUS = @PES_STATUS, PES_CHECKSUM = @PES_CHECKSUM
				WHERE PES_CODIGO = @PES_CODIGO
				
			END

	END

END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de pesagem de emissores
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_PESAGEM_ENTRADA] 

	@EMI_CODIGO	INT,
	@PLACA		VARCHAR(10)
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.*
	FROM TBL_PESAGENS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO
	WHERE T1.PES_STATUS = 0 AND T2.EMI_CODIGO = @EMI_CODIGO AND T3.VEI_PLACA = @PLACA 
	
END
GO



--------------------------------------------------------------------------------------------
-- Procedimento para busca de veículos internos
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_VEICULOS_INTERNOS] 
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.*, T2.EMI_NOME_FANTASIA AS EMISSOR, T3.VEI_PLACA AS PLACA, T4.RES_NOME AS RESIDUO 
	FROM TBL_PESAGENS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO
	INNER JOIN TBL_RESIDUOS T4 ON T1.PES_RESIDUO = T4.RES_CODIGO 
	WHERE T1.PES_STATUS = 0 
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para busca de pesagem
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_PESAGEM_BY_ID] 
	@PES_CODIGO INT
AS
BEGIN

	SET NOCOUNT ON

	SELECT T1.*, T2.EMI_CODIGO, T2.EMI_NOME_FANTASIA AS EMISSOR, T3.VEI_PLACA AS PLACA, T4.RES_NOME AS RESIDUO , T5.USU_NOME AS USUARIO
	FROM TBL_PESAGENS T1 
	INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO
	INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO
	INNER JOIN TBL_RESIDUOS T4 ON T1.PES_RESIDUO = T4.RES_CODIGO 
	INNER JOIN TBL_USUARIOS T5 ON T1.PES_USUARIO = T5.USU_CODIGO
	WHERE T1.PES_CODIGO = @PES_CODIGO
	
END
GO




--------------------------------------------------------------------------------------------
-- Procedimento para busca de pesagens
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_PESAGENS_SEARCH] 
	@SEARCH		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*, T2.EMI_CODIGO, T2.EMI_NOME_FANTASIA AS EMISSOR, T3.VEI_PLACA AS PLACA, T4.RES_NOME AS RESIDUO, T5.UNI_NOME AS UNIDADE, T6.USU_NOME AS USUARIO, 
		T1.PES_DATA_ENTRADA AS DATA_ENTRADA, T1.PES_DATA_SAIDA AS DATA_SAIDA
		FROM TBL_PESAGENS T1 
		INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO
		INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO
		INNER JOIN TBL_RESIDUOS T4 ON T1.PES_RESIDUO = T4.RES_CODIGO 
		INNER JOIN TBL_UNIDADES T5 ON T1.PES_UNIDADE = T5.UNI_CODIGO 
		INNER JOIN TBL_USUARIOS T6 ON T1.PES_USUARIO = T6.USU_CODIGO 
		WHERE (T2.EMI_NOME_FANTASIA LIKE @SEARCH OR T3.VEI_PLACA LIKE @SEARCH OR T3.VEI_PLACA LIKE @SEARCH OR T4.RES_NOME LIKE @SEARCH OR T4.RES_NOME LIKE @SEARCH) 
		ORDER BY PES_DATA_SAIDA DESC
	END
	ELSE
	BEGIN
		SELECT T1.*, T2.EMI_CODIGO, T2.EMI_NOME_FANTASIA AS EMISSOR, T3.VEI_PLACA AS PLACA, T4.RES_NOME AS RESIDUO, T5.UNI_NOME AS UNIDADE, T6.USU_NOME AS USUARIO, 
		T1.PES_DATA_ENTRADA AS DATA_ENTRADA, T1.PES_DATA_SAIDA AS DATA_SAIDA
		FROM TBL_PESAGENS T1 
		INNER JOIN TBL_EMISSORES T2 ON T1.PES_EMISSOR = T2.EMI_CODIGO
		INNER JOIN TBL_VEICULOS T3 ON T1.PES_VEICULO = T3.VEI_CODIGO
		INNER JOIN TBL_RESIDUOS T4 ON T1.PES_RESIDUO = T4.RES_CODIGO 
		INNER JOIN TBL_UNIDADES T5 ON T1.PES_UNIDADE = T5.UNI_CODIGO 
		INNER JOIN TBL_USUARIOS T6 ON T1.PES_USUARIO = T6.USU_CODIGO 
		ORDER BY PES_DATA_SAIDA DESC
	END
	
END
GO





















--------------------------------------------------------------------------------------------
-- Procedimento para inserir ou alterar grupo de usuários
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GRUPO_SAVE]
	@GRU_CODIGO			INT = NULL,
	@GRU_NOME			VARCHAR(50),
	@GRU_STATUS			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(GRU_NOME VARCHAR, GRU_STATUS INT)
								
		IF(@GRU_CODIGO IS NULL)
			BEGIN
			
				INSERT INTO TBL_GRUPOS (GRU_NOME, GRU_STATUS) 
						VALUES  (@GRU_NOME, @GRU_STATUS)

				SELECT @@identity AS 'GRU_CODIGO'

			END
		ELSE
			BEGIN
				UPDATE TBL_GRUPOS
				SET GRU_NOME = @GRU_NOME, GRU_STATUS = @GRU_STATUS
				WHERE GRU_CODIGO = @GRU_CODIGO
			END
	END

END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de grupo de usuários
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GRUPOS_SEARCH] 

	@SEARCH		VARCHAR(80) = NULL,
	@GRU_CODIGO	INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON

	IF(NOT @SEARCH IS NULL)
	BEGIN
		SELECT T1.*
		FROM TBL_GRUPOS T1 
		WHERE (GRU_NOME LIKE @SEARCH) AND GRU_STATUS >= 0 
		ORDER BY GRU_NOME
	END
	ELSE IF(NOT @GRU_CODIGO IS NULL)
	BEGIN
		SELECT T1.*
		FROM TBL_GRUPOS T1 
		WHERE T1.GRU_CODIGO = @GRU_CODIGO  AND GRU_STATUS >= 0 
		ORDER BY T1.GRU_NOME
	END
	ELSE
	BEGIN
		SELECT T1.*
		FROM TBL_GRUPOS T1 
		WHERE GRU_STATUS >= 0 
		ORDER BY GRU_NOME
	END
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_GRUPO] 
	@GRU_CODIGO		INT
AS
BEGIN

	-- DELETE FROM TBL_GRUPOS WHERE GRU_CODIGO = @GRU_CODIGO
	UPDATE TBL_GRUPOS SET GRU_STATUS = -2 WHERE GRU_CODIGO = @GRU_CODIGO
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de unidades
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_GRUPOS] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_GRUPOS ORDER BY GRU_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca da grupo por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_GRUPO_BY_NOME] 
	@NOME		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_GRUPOS WHERE GRU_NOME = @NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para exclusao de registros de pré-cadastro de grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GRUPOS_FLUSH] 
AS
BEGIN

	DELETE FROM TBL_GRUPOS WHERE GRU_STATUS = -1
	
END
GO








--------------------------------------------------------------------------------------------
-- Procedimento para busca de módulos
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_MODULOS] 
AS
BEGIN

	SET NOCOUNT ON
	SELECT * FROM TBL_MODULOS ORDER BY MOD_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de recursos por módulo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RECURSOS_BY_MODULO] 
	@MOD_NOME		VARCHAR(80)
AS
BEGIN

	SET NOCOUNT ON
	SELECT T1.*, T2.MOD_NOME AS MODULO
	FROM TBL_RECURSOS T1 
	INNER JOIN TBL_MODULOS T2 ON T1.REC_MODULO = T2.MOD_CODIGO
	WHERE T2.MOD_NOME = @MOD_NOME
	ORDER BY T1.REC_NOME DESC
	
END
GO


--------------------------------------------------------------------------------------------
-- Procedimento para busca de permissões nome de recurso e grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_PERMISSAO_BY_NOME_RECURSO] 
	@GRU_CODIGO		VARCHAR(80),
	@REC_NOME		VARCHAR(80)
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT T1.*
	FROM REL_PERMISSOES T1 
	INNER JOIN TBL_RECURSOS T2 ON T1.PER_RECURSO = T2.REC_CODIGO
	WHERE T1.PER_GRUPO = @GRU_CODIGO AND T2.REC_NOME = @REC_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de recurso por nome
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_RECURSO_BY_NOME] 
	@REC_NOME		VARCHAR(80)
AS
BEGIN

	SET NOCOUNT ON
	SELECT T1.*
	FROM TBL_RECURSOS T1 
	WHERE T1.REC_NOME = @REC_NOME
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para salvar permissão de grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_PERMISSAO_SAVE]
	@GRU_CODIGO			INT,
	@REC_CODIGO			INT
AS
BEGIN

	SET NOCOUNT ON;
	
	BEGIN
		DECLARE @CAMPOS TABLE(GRU_CODIGO INT, REC_CODIGO INT)
								
		INSERT INTO REL_PERMISSOES (PER_GRUPO, PER_RECURSO) 
				VALUES  (@GRU_CODIGO, @REC_CODIGO)

		SELECT @@identity AS 'PER_CODIGO'

	END

END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de permissões por grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_GET_PERMISSOES_BY_ID_GRUPO] 
	@GRU_CODIGO		VARCHAR(80) = NULL
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT T1.*, T2.REC_NOME AS RECURSO, T3.MOD_NOME AS MODULO, T4.GRU_NOME AS GRUPO
	FROM REL_PERMISSOES T1 
	INNER JOIN TBL_RECURSOS T2 ON T1.PER_RECURSO = T2.REC_CODIGO
	INNER JOIN TBL_MODULOS T3 ON T2.REC_MODULO = T3.MOD_CODIGO
	INNER JOIN TBL_GRUPOS T4 ON T1.PER_GRUPO = T4.GRU_CODIGO 
	WHERE PER_GRUPO = @GRU_CODIGO
	ORDER BY MODULO DESC
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para exclusão de permissão de grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_DELETE_PERMISSAO] 
	@PER_CODIGO		INT
AS
BEGIN

	DELETE FROM REL_PERMISSOES WHERE PER_CODIGO = @PER_CODIGO
	
END
GO

--------------------------------------------------------------------------------------------
-- Procedimento para busca de permissões por grupo
--------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[PRC_ACL_CHECK]
	@ACAO			VARCHAR(80),
	@GRU_CODIGO		VARCHAR(80)
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT T1.*
	FROM REL_PERMISSOES T1 
	INNER JOIN TBL_RECURSOS T2 ON T1.PER_RECURSO = T2.REC_CODIGO
	WHERE PER_GRUPO = @GRU_CODIGO AND T2.REC_ACAO = @ACAO
	
END
GO

