USE [SGP] 

INSERT INTO [SGP].[dbo].[TBL_UNIDADES]
           ([UNI_NOME])
     VALUES
           ('Escritório'), 
           ('PGR'), 
           ('CO'), 
           ('Transbordo')
GO

INSERT INTO [SGP].[dbo].[TBL_GRUPOS]
           ([GRU_NOME]
           ,[GRU_STATUS])
     VALUES
           ('Administrador', 1), 
           ('Balanceiro', 1), 
           ('Fechamento', 1) 
GO

INSERT INTO [SGP].[dbo].[TBL_USUARIOS]
           ([USU_UNIDADE]
           ,[USU_GRUPO]
           ,[USU_NOME]
           ,[USU_EMAIL]
           ,[USU_LOGIN]
           ,[USU_SENHA]
           ,[USU_STATUS])
     VALUES
           (1
           ,1
           ,'Administrador'
           ,'sias@proactiva.com.br'
           ,'ADMIN'
           ,HASHBYTES('MD5', 'ADMIN')
           ,1), 
           (2
           ,2
           ,'Balanceiro'
           ,'sias@proactiva.com.br'
           ,'PGR'
           ,HASHBYTES('MD5', 'PGR')
           ,1)
           
GO

INSERT INTO [SGP].[dbo].[TBL_VEICULOS_TIPOS]
           ([VET_NOME])
     VALUES
           ('Compactador'), 
           ('Transportador')
GO

INSERT INTO [SGP].[dbo].[TBL_VEICULOS]
           ([VEI_NOME]
           ,[VEI_TIPO]
           ,[VEI_PLACA]
           ,[VEI_TARA] 
           ,[VEI_STATUS])
     VALUES
           ('Volkswagen VW-1100'
           ,2
           ,'MDB3352'
           ,'15000'
           ,1), 
           ('Ford F-50000'
           ,1
           ,'MZX0025'
           ,'11000'
           ,1) 
GO

INSERT INTO [SGP].[dbo].[TBL_RESIDUOS_TIPOS]
           ([RET_NOME])
     VALUES
           ('Comum'), 
           ('Químico'), 
           ('Hospitalar')
GO

INSERT INTO [SGP].[dbo].[TBL_RESIDUOS]
           ([RES_TIPO], 
           [RES_NOME], 
           [RES_STATUS])
     VALUES
           (1, 'Resíduo Domiciliar', 1), 
           (2, 'Resíduo Químico', 1),
           (3, 'Resíduo Hospitalar', 1)
GO


INSERT INTO SGP.dbo.TBL_CIDADES SELECT * FROM SIAS.dbo.TB_CIDADE ORDER BY ID_CIDADE
GO


INSERT INTO [SGP].[dbo].[TBL_MODULOS]
           ([MOD_NOME])
     VALUES
           ('Usuários'), 
           ('Veículos'), 
           ('Resíduos'), 
           ('Emissores'), 
           ('Pesagens') 
GO



INSERT INTO [SGP].[dbo].[TBL_RECURSOS]
           ([REC_MODULO]
           ,[REC_NOME]
           ,[REC_ACAO])
     VALUES
           (1
           ,'Listagem de Usuários' 
           ,'usuarios-listagem'), 
           (1
           ,'Cadastro de Usuário' 
           ,'usuarios-cadastrar'), 
           (1
           ,'Alteração de Usuário' 
           ,'usuarios-alterar'), 
           (1
           ,'Exclusão de Usuário' 
           ,'usuarios-excluir'), 
           (1
           ,'Sair do Sistema' 
           ,'usuarios-sair'), 
           (1
           ,'Listagem de Grupos' 
           ,'grupos-listagem'), 
           (1
           ,'Cadastro de Grupo' 
           ,'grupos-cadastrar'), 
           (1
           ,'Alteração de Grupo' 
           ,'grupos-alterar'), 
           (1
           ,'Exclusão de Grupo' 
           ,'grupos-excluir'), 
           (1
           ,'Relatórios de Acesso' 
           ,'relatorios-acesso'), 
           (2
           ,'Listagem de Veículos' 
           ,'veiculos-listagem'), 
           (2
           ,'Cadastro de Veículo' 
           ,'veiculos-cadastrar'), 
           (2
           ,'Alteração de Veículo' 
           ,'veiculos-alterar'), 
           (2
           ,'Exclusão de Veículo' 
           ,'veiculos-excluir'), 
           (3
           ,'Listagem de Resíduos' 
           ,'residuos-listagem'), 
           (3
           ,'Cadastro de Resíduo' 
           ,'residuos-cadastrar'), 
           (3
           ,'Alteração de Resíduo' 
           ,'residuos-alterar'), 
           (3
           ,'Exclusão de Resíduo' 
           ,'residuos-excluir'), 
           (4
           ,'Listagem de Emissores' 
           ,'emissores-listagem'), 
           (4
           ,'Cadastro de Emissor' 
           ,'emissores-cadastrar'), 
           (4
           ,'Alteração de Emissor' 
           ,'emissores-alterar'), 
           (4
           ,'Exclusão de Emissor' 
           ,'emissores-excluir'), 
           (5
           ,'Listagem de Pesagens' 
           ,'pesagens-listagem'), 
           (5
           ,'Cadastro de Pesagem' 
           ,'pesagens-cadastrar'), 
           (5
           ,'Alteração de Pesagem' 
           ,'pesagens-alterar'), 
           (5
           ,'Exclusão de Pesagem' 
           ,'pesagens-excluir'), 
		   (5
           ,'Impressão de Ticket Pesagem' 
           ,'pesagens-impressao'),            
		   (5
           ,'Relatórios de Pesagens' 
           ,'pesagens-relatorios'),
		   (5
           ,'Impressão de Relatórios de Pesagens' 
           ,'pesagens-relatorios-impressao'),
		   (5
           ,'Exportação de Relatórios de Pesagens' 
           ,'pesagens-relatorios-exportacao')
           
GO


INSERT INTO [SGP].[dbo].[REL_PERMISSOES]
           ([PER_GRUPO]
           ,[PER_RECURSO])
     VALUES
           (1, 1), 
           (1, 2), 
           (1, 3), 
           (1, 4), 
           (1, 5), 
           (1, 6), 
           (1, 7), 
           (1, 8), 
           (1, 9), 
           (1, 10), 
           (1, 11), 
           (1, 12), 
           (1, 13), 
           (1, 14), 
           (1, 15), 
           (1, 16), 
           (1, 17), 
           (1, 18), 
           (1, 19), 
           (1, 20), 
           (1, 21), 
           (1, 22), 
           (1, 23), 
           (1, 24), 
           (1, 25), 
           (1, 26), 
           (1, 27),
           (1, 28),
           (1, 29),
           (1, 30)
           
GO

           
           
           







