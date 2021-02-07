CREATE TABLE [dbo].[Uzivatel]
(
	[IdUzivatel] INT NOT NULL  identity, 
    [Heslo] NVARCHAR(300) NOT NULL, 
    [Email] NVARCHAR(300) NOT NULL, 
    [Jmeno] NVARCHAR(300) NOT NULL, 
    [Prijmeni] NVARCHAR(300) NOT NULL, 
    CONSTRAINT [PK_Uzivatel] PRIMARY KEY ([IdUzivatel]),
    CONSTRAINT UK_Email UNIQUE(Email),
    CONSTRAINT UK_Uzivatel UNIQUE(Email,Heslo)
)
