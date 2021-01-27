CREATE TABLE [dbo].[Uzivatel]
(
	[IdUzivatel] INT NOT NULL  identity, 
    [UzivatelskeJmeno] NVARCHAR(50) NOT NULL, 
    [Heslo] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Uzivatel] PRIMARY KEY ([IdUzivatel])
)
