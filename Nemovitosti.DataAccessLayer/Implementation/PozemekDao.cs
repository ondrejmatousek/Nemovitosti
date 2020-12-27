using Dapper;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
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
            string query = @"INSERT INTO Nemovitosti.dbo.Pozemek (NazevInzeratu, Cena, VelikostPozemku, DatumVytvoreniInzeratu)
                             VALUES(@NazevInzeratu, @Cena, @VelikostPozemku, @DatumVytvoreniInzeratu)
                             SELECT IdPozemek FROM Nemovitosti.dbo.Pozemek WHERE Pozemek.IdPozemek = Scope_Identity()";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                pozemek.DatumVytvoreniInzeratu = DateTime.Now;
                Pozemek pozemekZDb = dbConnection.Query<Pozemek>(query, new { pozemek.IdPozemek, pozemek.NazevInzeratu, pozemek.Cena, pozemek.VelikostPozemku, pozemek.DatumVytvoreniInzeratu }).SingleOrDefault();
                pozemek.IdPozemek = pozemekZDb.IdPozemek;
            }
        }

        public Pozemek GetById(int id)
        {
            string query = "SELECT Pozemek.IdPozemek, Pozemek.NazevInzeratu, Pozemek.Cena, Pozemek.VelikostPozemku, Pozemek.DatumVytvoreniInzeratu FROM Nemovitosti.dbo.Pozemek WHERE Pozemek.IdPozemek = @id";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                return dbConnection.Query<Pozemek>(query, new { id }).SingleOrDefault();
            }
        }

        public void Update(Pozemek pozemek)
        {
            string query = "UPDATE Nemovitosti.dbo.Pozemek SET(NazevInzeratu = @NazevInzeratu, Cena = @Cena, VelikostPozemku = @VelikostPozemku) WHERE Pozemek.IdPozemek = @IdPozemek";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                int PocetUpravenychRadku = dbConnection.Execute(query, new { IdPozemek = pozemek.IdPozemek, NazevInzeratu = pozemek.NazevInzeratu, Cena = pozemek.Cena, VelikostPozemku = pozemek.VelikostPozemku });
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
