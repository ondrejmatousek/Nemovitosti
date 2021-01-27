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
    public class UzivatelDao : IUzivatelDao
    {
        private ConnectionStringSettings _connectionString;

        public UzivatelDao(ConnectionStringSettings connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(_connectionString));
        }

        public void Insert(Uzivatel uzivatel)
        {
            string query = @"INSERT INTO Nemovitosti.dbo.Uzivatel (UzivatelskeJmeno, Heslo)
                             VALUES (@UzivatelskeJmeno, @Heslo)
                             SELECT IdUzivatel FROM Nemovitosti.dbo.Uzivatel WHERE Uzivatel.IdUzivatel = Scope_Identity()";

            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZdb = dbConnection.Query<Uzivatel>(query, new { uzivatel.IdUzivatel, uzivatel.UzivatelskeJmeno, uzivatel.Heslo }).SingleOrDefault();
                uzivatel.IdUzivatel = uzivatelZdb.IdUzivatel;
            }
        }

        public Uzivatel GetById(int Id)
        {
            string query = @"SELECT Uzivatel.IdUzivatel, Uzivatel.UzivatelskeJmeno, Uzivatel.Heslo FROM Nemovitosti.dbo.Uzivatel WHERE IdUzivatel = @IdUzivatel";
            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZDb = dbConnection.Query<Uzivatel>(query, new { Id }).SingleOrDefault();
                return uzivatelZDb;
            }
        }

        public void Update(Uzivatel uzivatel)
        {
            string query = @"UPDATE Nemovitosti.dbo.Uzivatel SET(UzivatelskeJmeno = @UzivatelskeJmeno, Heslo = @Heslo) WHERE Uzivatel.IdUzivatel = @IdUzivatel";
            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZDb = dbConnection.Query<Uzivatel>(query, new { IdUzivatel = uzivatel.IdUzivatel, uzivatel.UzivatelskeJmeno, uzivatel.Heslo }).SingleOrDefault();
            }
        }
    }
}
