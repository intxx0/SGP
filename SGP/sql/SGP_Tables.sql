USE [SGP]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


--------------------------------------------------------------------------------------------
-- Unidades
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_UNIDADES](
	[UNI_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[UNI_NOME] [varchar](80) NOT NULL,
 CONSTRAINT [PK_TBL_UNIDADES] PRIMARY KEY CLUSTERED 
(
	[UNI_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--------------------------------------------------------------------------------------------
-- Grupos de usuários
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_GRUPOS](
	[GRU_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[GRU_NOME] [varchar](100) NOT NULL, 
	[GRU_STATUS] [int] NOT NULL
) ON [PRIMARY]

GO


--------------------------------------------------------------------------------------------
-- Usuários
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_USUARIOS](
	[USU_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[USU_UNIDADE] [int] NOT NULL,
	[USU_GRUPO] [int] NOT NULL,
	[USU_NOME] [varchar](80) NOT NULL,
	[USU_EMAIL] [varchar](170) NOT NULL,
	[USU_LOGIN] [varchar](50) NULL,
	[USU_SENHA] [varchar](32) NULL,
	[USU_OBSERVACOES] [varchar](255) NULL,
	[USU_DATA_CADASTRO] [datetime] NOT NULL,
	[USU_STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TBL_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[USU_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave Primária da tabela.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_CODIGO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira da unidade da empresa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_UNIDADE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_NOME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Mail do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_EMAIL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_LOGIN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Senha do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_SENHA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data de cadastro do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_DATA_CADASTRO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_USUARIOS', @level2type=N'COLUMN',@level2name=N'USU_STATUS'
GO

ALTER TABLE [dbo].[TBL_USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_USUARIOS_TBL_UNIDADES] FOREIGN KEY([USU_UNIDADE])
REFERENCES [dbo].[TBL_UNIDADES] ([UNI_CODIGO])
GO

-- ALTER TABLE [dbo].[TBL_USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_USUARIOS_TBL_GRUPOS] FOREIGN KEY([USU_GRUPO])
-- REFERENCES [dbo].[TBL_GRUPOS] ([GRU_CODIGO])
-- GO

ALTER TABLE [dbo].[TBL_USUARIOS] CHECK CONSTRAINT [FK_TBL_USUARIOS_TBL_UNIDADES]
GO

-- ALTER TABLE [dbo].[TBL_USUARIOS] CHECK CONSTRAINT [FK_TBL_USUARIOS_TBL_GRUPOS]
-- GO

ALTER TABLE [dbo].[TBL_USUARIOS] ADD  CONSTRAINT [DF_TBL_USUARIOS_USU_DATA_CADASTRO]  DEFAULT (getdate()) FOR [USU_DATA_CADASTRO]
GO

ALTER TABLE [dbo].[TBL_USUARIOS] ADD  CONSTRAINT [DF_TBL_USUARIOS_USU_STATUS]  DEFAULT (1) FOR [USU_STATUS]
GO


--------------------------------------------------------------------------------------------
-- Registro de acesso de usuários
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_ACESSOS](
	[ACE_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[ACE_USUARIO] [int] NOT NULL,
	[ACE_DATA_ACESSO] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_ACESSOS] PRIMARY KEY CLUSTERED 
(
	[ACE_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TBL_ACESSOS] ADD  CONSTRAINT [DF_TBL_ACESSOS_ACE_DATA_ACESSO]  DEFAULT (getdate()) FOR [ACE_DATA_ACESSO]
GO



--------------------------------------------------------------------------------------------
-- Tipos de veículos
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_VEICULOS_TIPOS](
	[VET_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[VET_NOME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_VEICULOS_TIPOS] PRIMARY KEY CLUSTERED 
(
	[VET_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--------------------------------------------------------------------------------------------
-- Veículos
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_VEICULOS](
	[VEI_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[VEI_NOME] [varchar](50) NOT NULL,
	[VEI_TIPO] [int] NOT NULL,
	[VEI_PLACA] [varchar](7) NOT NULL,
	[VEI_TARA] [int] NOT NULL,
	[VEI_STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TBL_VEICULOS] PRIMARY KEY CLUSTERED 
(
	[VEI_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TBL_VEICULOS] ADD  CONSTRAINT [DF_TBL_VEICULOS_VEI_STATUS]  DEFAULT (1) FOR [VEI_STATUS]
GO


--------------------------------------------------------------------------------------------
-- Tipos de resíduos
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_RESIDUOS_TIPOS](
	[RET_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[RET_NOME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_RESIDUOS_TIPOS] PRIMARY KEY CLUSTERED 
(
	[RET_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--------------------------------------------------------------------------------------------
-- Resíduos
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_RESIDUOS](
	[RES_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[RES_TIPO] [int] NOT NULL, 
	[RES_NOME] [varchar](80) NOT NULL,
	[RES_STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TBL_RESIDUOS] PRIMARY KEY CLUSTERED 
(
	[RES_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TBL_RESIDUOS] ADD  CONSTRAINT [DF_TBL_RESIDUOS_RES_STATUS]  DEFAULT (1) FOR [RES_STATUS]
GO


--------------------------------------------------------------------------------------------
-- Emissores
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_EMISSORES](
	[EMI_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[EMI_CIDADE] [bigint] NOT NULL,
	[EMI_NOME_FANTASIA] [varchar](80) NOT NULL,
	[EMI_RAZAO_SOCIAL] [varchar](80) NOT NULL,
	[EMI_TIPO_PESSOA] [int] NOT NULL,
	[EMI_TIPO_CLIENTE] [int] NOT NULL,
	[EMI_CNPJ] [varchar](18) NOT NULL,
	[EMI_CPF] [varchar](14) NOT NULL,
	[EMI_IE] [varchar](20) NOT NULL,
	[EMI_IM] [varchar](20) NOT NULL,
	[EMI_ENDERECO] [varchar](80) NOT NULL,
	[EMI_NUMERO] [varchar](20) NOT NULL,
	[EMI_BAIRRO] [varchar](80) NOT NULL,
	[EMI_EMAIL] [varchar](170) NOT NULL,
	[EMI_TELEFONE] [varchar](40) NOT NULL,
	[EMI_CELULAR] [varchar](40) NOT NULL,
	[EMI_OBSERVACOES] [varchar](255) NOT NULL,
	--- [EMI_STATUS] [bit] NOT NULL,
	[EMI_STATUS] [int] NOT NULL, --- -2=Excluído -1=Pré-Cadastro 0=Inativo 1=Ativo
 CONSTRAINT [PK_TBL_EMISSORES] PRIMARY KEY CLUSTERED 
(
	[EMI_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TBL_EMISSORES] ADD  CONSTRAINT [DF_TBL_EMISSORES_EMI_STATUS]  DEFAULT (1) FOR [EMI_STATUS]
GO


--------------------------------------------------------------------------------------------
-- Pesagens
--------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[TBL_PESAGENS](
	[PES_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	--[PES_CODIGO] [varchar] (32) NOT NULL,
	[PES_UNIDADE] [int] NOT NULL,
	[PES_USUARIO] [int] NOT NULL,
	[PES_VEICULO] [int] NOT NULL,
	[PES_RESIDUO] [int] NOT NULL,
	[PES_EMISSOR] [int] NOT NULL,
	[PES_PESO_BRUTO] [real] NOT NULL,
	[PES_PESO_LIQUIDO] [real] NOT NULL,
	[PES_PESO_TARA] [real] NOT NULL,
	[PES_DATA_ENTRADA] [datetime],
	[PES_DATA_SAIDA] [datetime],
	[PES_OBSERVACOES] [varchar](255) NOT NULL,
	[PES_STATUS] [bit] NOT NULL,
	[PES_CHECKSUM] [varchar] (32) NOT NULL, 
 CONSTRAINT [PK_TBL_PESAGENS] PRIMARY KEY CLUSTERED 
(
	[PES_CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave Primária da tabela.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_CODIGO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira da unidade da empresa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_UNIDADE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_USUARIO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira do veículo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_VEICULO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira do resíduo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_RESIDUO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira do emissor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_EMISSOR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data e hora de entrada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_DATA_ENTRADA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data e hora de saída' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_DATA_SAIDA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Observações da pesagem' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TBL_PESAGENS', @level2type=N'COLUMN',@level2name=N'PES_OBSERVACOES'
GO

ALTER TABLE [dbo].[TBL_PESAGENS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PESAGENS_TBL_UNIDADES] FOREIGN KEY([PES_UNIDADE])
REFERENCES [dbo].[TBL_UNIDADES] ([UNI_CODIGO])
GO

ALTER TABLE [dbo].[TBL_PESAGENS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PESAGENS_TBL_USUARIOS] FOREIGN KEY([PES_USUARIO])
REFERENCES [dbo].[TBL_USUARIOS] ([USU_CODIGO])
GO

ALTER TABLE [dbo].[TBL_PESAGENS] CHECK CONSTRAINT [FK_TBL_PESAGENS_TBL_UNIDADES]
GO

ALTER TABLE [dbo].[TBL_PESAGENS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PESAGENS_TBL_VEICULOS] FOREIGN KEY([PES_VEICULO])
REFERENCES [dbo].[TBL_VEICULOS] ([VEI_CODIGO])
GO

ALTER TABLE [dbo].[TBL_PESAGENS] CHECK CONSTRAINT [FK_TBL_PESAGENS_TBL_VEICULOS]
GO

ALTER TABLE [dbo].[TBL_PESAGENS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PESAGENS_TBL_RESIDUOS] FOREIGN KEY([PES_RESIDUO])
REFERENCES [dbo].[TBL_RESIDUOS] ([RES_CODIGO])
GO

ALTER TABLE [dbo].[TBL_PESAGENS] CHECK CONSTRAINT [FK_TBL_PESAGENS_TBL_RESIDUOS]
GO

ALTER TABLE [dbo].[TBL_PESAGENS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_PESAGENS_TBL_EMISSORES] FOREIGN KEY([PES_EMISSOR])
REFERENCES [dbo].[TBL_EMISSORES] ([EMI_CODIGO])
GO

ALTER TABLE [dbo].[TBL_PESAGENS] CHECK CONSTRAINT [FK_TBL_PESAGENS_TBL_EMISSORES]
GO

ALTER TABLE [dbo].[TBL_PESAGENS] ADD  CONSTRAINT [DF_TBL_PESAGENS_PES_DATA_ENTRADA]  DEFAULT (getdate()) FOR [PES_DATA_ENTRADA]
GO

ALTER TABLE [dbo].[TBL_PESAGENS] ADD  CONSTRAINT [DF_TBL_PESAGENS_PES_DATA_SAIDA]  DEFAULT (getdate()) FOR [PES_DATA_SAIDA]
GO



CREATE TABLE [dbo].[TBL_CIDADES](
	[CID_CODIGO] [bigint] NOT NULL,
	[CID_NOME] [varchar](100) NOT NULL,
	[CID_UF] [varchar](2) NOT NULL,
	[CID_ESTADO] [varchar](50) NULL
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[REL_EMISSORES_VEICULOS](
	[EMV_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[EMV_EMISSOR] [int] NOT NULL,
	[EMV_VEICULO] [int] NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[REL_EMISSORES_RESIDUOS](
	[EMR_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[EMR_EMISSOR] [int] NOT NULL,
	[EMR_RESIDUO] [int] NOT NULL
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[TBL_MODULOS](
	[MOD_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[MOD_NOME] [varchar](100) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[TBL_RECURSOS](
	[REC_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[REC_MODULO] [int] NOT NULL, 
	[REC_NOME] [varchar](100) NOT NULL, 
	[REC_ACAO] [varchar](50) NOT NULL 
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[REL_PERMISSOES](
	[PER_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[PER_GRUPO] [int] NOT NULL,
	[PER_RECURSO] [int] NOT NULL
) ON [PRIMARY]

GO



