using Dapper;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.DomainModel.Model.Ciselniky;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Nemovitosti.DataAccessLayer.Implementation
{
    public class PozemekDao : IPozemekDao
    {
        private readonly ConnectionStringSettings connString;
        public PozemekDao(ConnectionStringSettings connString)
        {
            this.connString = connString;
        }

        public void Insert(Pozemek pozemek)
        {
            string query = @"INSERT INTO Nemovitosti.dbo.Pozemek (NazevInzeratu, Cena, VelikostPozemku, DatumVytvoreniInzeratu, TypPozemkuId, ProdejNeboPronajemId)
                             VALUES(@NazevInzeratu, @Cena, @VelikostPozemku, @DatumVytvoreniInzeratu, @TypPozemkuId, @ProdejNeboPronajemId)
                             SELECT IdPozemek FROM Nemovitosti.dbo.Pozemek WHERE Pozemek.IdPozemek = Scope_Identity()";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                pozemek.DatumVytvoreniInzeratu = DateTime.Now;
                Pozemek pozemekZDb = dbConnection.Query<Pozemek>(query, new
                {
                    pozemek.IdPozemek,
                    pozemek.NazevInzeratu,
                    pozemek.Cena,
                    pozemek.VelikostPozemku,
                    pozemek.DatumVytvoreniInzeratu,
                    TypPozemkuId = pozemek.CiselnikTypPozemku.Id,
                    ProdejNeboPronajemId = pozemek.CiselnikProdejNeboPronajem.Id
                }).SingleOrDefault();
                pozemek.IdPozemek = pozemekZDb.IdPozemek;
            }
        }

        public Pozemek GetById(int id)
        {
            string query = "SELECT Pozemek.IdPozemek, Pozemek.NazevInzeratu, Pozemek.Cena, Pozemek.VelikostPozemku, Pozemek.DatumVytvoreniInzeratu, Pozemek.TypPozemkuId," +
                           " Pozemek.ProdejNeboPronajemId, CiselnikTypPozemku.Id, CiselnikTypPozemku.Nazev, CiselnikProdejNeboPronajem.Id, CiselnikProdejNeboPronajem.Nazev" +
                           " FROM Nemovitosti.dbo.Pozemek" +
                           " LEFT OUTER JOIN CiselnikTypPozemku ON Pozemek.TypPozemkuId = CiselnikTypPozemku.Id" +
                           " LEFT OUTER JOIN CiselnikProdejNeboPronajem ON Pozemek.ProdejNeboPronajemId = CiselnikProdejNeboPronajem.Id" +
                           " WHERE Pozemek.IdPozemek = @id";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                Pozemek pozemekZDb = dbConnection.Query<Pozemek, CiselnikTypPozemku, CiselnikProdejNeboPronajem, Pozemek>(query,
                    map: (pozemek, ciselnikTypPozemku, ciselnikProdejNeboPronajem) =>
                    {
                        Pozemek pozemekMapovani = new Pozemek();
                        if (pozemek != null)
                        {
                            pozemekMapovani = pozemek;
                        }
                        if (ciselnikTypPozemku != null)
                        {
                            pozemekMapovani.CiselnikTypPozemku = ciselnikTypPozemku;
                        }
                        if (ciselnikProdejNeboPronajem != null)
                        {
                            pozemekMapovani.CiselnikProdejNeboPronajem = ciselnikProdejNeboPronajem;
                        }

                        return pozemekMapovani;
                    },
                param: new { id }, splitOn: "IdPozemek, Id, Id").SingleOrDefault();
                return pozemekZDb;
            }
        }

        public void Update(Pozemek pozemek)
        {
            string query = "UPDATE Nemovitosti.dbo.Pozemek SET(NazevInzeratu = @NazevInzeratu, Cena = @Cena, VelikostPozemku = @VelikostPozemku, TypPozemkuId = @TypPozemkuId, ProdejNeboPronajemId = @ProdejNeboPronajemId) WHERE Pozemek.IdPozemek = @IdPozemek";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                int PocetUpravenychRadku = dbConnection.Execute(query, new { IdPozemek = pozemek.IdPozemek, NazevInzeratu = pozemek.NazevInzeratu, Cena = pozemek.Cena, VelikostPozemku = pozemek.VelikostPozemku, TypPozemkuId = pozemek.CiselnikTypPozemku.Id, ProdejNeboPronajemId = pozemek.CiselnikProdejNeboPronajem.Id });
                if (PocetUpravenychRadku != 1)
                {
                    throw new Exception();
                }
            }
        }

        public void Delete(Pozemek pozemek)
        {
            string query = "DELETE FROM Nemovitosti.dbo.Pozemek WHERE Pozemek.IdPozemek = @IdPozemek";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                int PocetUpravenychRadku = dbConnection.Execute(query, new { IdPozemek = pozemek.IdPozemek });
                if (PocetUpravenychRadku != 1)
                {
                    throw new Exception();
                }
            }
        }
    }
}
