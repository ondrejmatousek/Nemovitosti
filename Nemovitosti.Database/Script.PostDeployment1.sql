/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Číselník TypPozemku
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (1, 'Stavební')
GO
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (2, 'Zahrady')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (3, 'Louky')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (4, 'Lesy')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (5, 'Komerční')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (6, 'Pole')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (7, 'Zemědělské')
GO          
INSERT INTO CiselnikTypPozemku (Id, Nazev) VALUES (8, 'Ostatní')
GO

--Číselník ProdejNeboPronájem
INSERT INTO CiselnikProdejNeboPronajem (Id, Nazev) VALUES (1, 'Prodej')
GO
INSERT INTO CiselnikProdejNeboPronajem (Id, Nazev) VALUES (2, 'Pronájem')
GO          
INSERT INTO CiselnikProdejNeboPronajem (Id, Nazev) VALUES (3, 'Dražby')
GO
