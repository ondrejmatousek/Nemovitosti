﻿CREATE TABLE [dbo].[Byt]
(
	[IdByt] INT NOT NULL  identity, 
    [NazevInzeratu] NVARCHAR(300) NOT NULL, 
    [Cena] INT NOT NULL, 
    [VelikostBytu] INT NOT NULL 
    CONSTRAINT [PK_Byt] PRIMARY KEY CLUSTERED ([IdByt] ASC)
)
