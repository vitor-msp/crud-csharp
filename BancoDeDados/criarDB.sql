CREATE DATABASE [CRUD]
GO
USE [CRUD]
GO
CREATE TABLE [dbo].[Cliente](
	[id_cli] [int] IDENTITY(1,1) NOT NULL,
	[nome_cli] [varchar](255) NOT NULL,
	[endereco_cli] [varchar](30) NULL,
	[cidade_cli] [varchar](20) NULL,
	[cep_cli] [char](8) NULL,
	[uf_cli] [char](2) NULL,
	CONSTRAINT [PK_Cliente] PRIMARY KEY (id_cli)
)
GO