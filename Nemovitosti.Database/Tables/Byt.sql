CREATE TABLE [dbo].[Byt]
(
	[IdByt] INT NOT NULL PRIMARY KEY identity, 
    [NazevInzeratu] NVARCHAR(300) NOT NULL, 
    [Cena] INT NOT NULL, 
    [VelikostBytu] INT NOT NULL 
)
