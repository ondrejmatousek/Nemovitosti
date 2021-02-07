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
            string query = @"INSERT INTO Nemovitosti.dbo.Uzivatel (Heslo, Email, Jmeno, Prijmeni)
                             VALUES (@Heslo, @Email, @Jmeno, @Prijmeni)
                             SELECT IdUzivatel FROM Nemovitosti.dbo.Uzivatel WHERE Uzivatel.IdUzivatel = Scope_Identity()";

            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZdb = dbConnection.Query<Uzivatel>(query, new { uzivatel.IdUzivatel, uzivatel.Heslo, uzivatel.Email, uzivatel.Jmeno, uzivatel.Prijmeni }).SingleOrDefault();
                uzivatel.IdUzivatel = uzivatelZdb.IdUzivatel;
            }
        }

        public Uzivatel GetById(int Id)
        {
            string query = @"SELECT Uzivatel.IdUzivatel, Uzivatel.Heslo, Uzivatel.Email, Uzivatel.Jmeno, Uzivatel.Prijmeni FROM Nemovitosti.dbo.Uzivatel WHERE IdUzivatel = @IdUzivatel";
            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZDb = dbConnection.Query<Uzivatel>(query, new { Id }).SingleOrDefault();
                return uzivatelZDb;
            }
        }

        public Uzivatel GetByEmailAndPassword(Uzivatel uzivatel)
        {
            string query = @"SELECT Uzivatel.IdUzivatel, Uzivatel.Heslo, Uzivatel.Email, Uzivatel.Jmeno, Uzivatel.Prijmeni FROM Nemovitosti.dbo.Uzivatel WHERE Email = @Email AND Heslo=@Heslo";
            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZDb = dbConnection.Query<Uzivatel>(query, new { Email = uzivatel.Email, Heslo = uzivatel.Heslo }).SingleOrDefault();
                return uzivatelZDb;
            }
        }

        public void Update(Uzivatel uzivatel)
        {
            string query = @"UPDATE Nemovitosti.dbo.Uzivatel SET(Heslo = @Heslo, Email = @Email, Jmeno = @Jmeno, Prijmeni = @Prijmeni) WHERE Uzivatel.IdUzivatel = @IdUzivatel";
            using (DbConnection dbConnection = new SqlConnection(_connectionString.ConnectionString))
            {
                Uzivatel uzivatelZDb = dbConnection.Query<Uzivatel>(query, new { IdUzivatel = uzivatel.IdUzivatel, uzivatel.Heslo, uzivatel.Email, uzivatel.Jmeno, uzivatel.Prijmeni }).SingleOrDefault();
            }
        }
    }
}
