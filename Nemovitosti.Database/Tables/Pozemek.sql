CREATE TABLE [dbo].[Pozemek]
(
	[IdPozemek] INT NOT NULL  identity, 
    [NazevInzeratu] NVARCHAR(300) NOT NULL, 
    [Cena] INT NOT NULL, 
    [VelikostPozemku] INT NOT NULL, 
    [DatumVytvoreniInzeratu] DATETIME2 NOT NULL,
    [TypPozemkuId] INT NULL

    CONSTRAINT [PK_Pozemek] PRIMARY KEY CLUSTERED ([IdPozemek] ASC), 
    [ProdejNeboPronajemId] INT NOT NULL, 
    CONSTRAINT [FK_Pozemek_CiselnikTypPozemku] FOREIGN KEY (TypPozemkuId) REFERENCES [CiselnikTypPozemku]([Id]),
    CONSTRAINT [FK_Pozemek_CiselnikProdejNeboPronajem] FOREIGN KEY (ProdejNeboPronajemId) REFERENCES [CiselnikProdejNeboPronajem]([Id])
)
