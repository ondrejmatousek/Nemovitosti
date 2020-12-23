CREATE TABLE [dbo].[Dum]
(
	[IdDum] INT NOT NULL  identity, 
    [NazevInzeratu] NVARCHAR(300) NOT NULL, 
    [Cena] INT NOT NULL, 
    [VelikostPozemku] INT NOT NULL, 
    [DatumVytvoreniInzeratu] DATETIME2 NOT NULL
    CONSTRAINT [PK_Dum] PRIMARY KEY CLUSTERED ([IdDum] ASC)
)
