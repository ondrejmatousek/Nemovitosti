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
    public class DumDao : IDumDao
    {
        private ConnectionStringSettings connString;
        public DumDao(ConnectionStringSettings connString)
        {
            this.connString = connString ?? throw new ArgumentNullException(nameof(connString));
        }

        public void Insert(Dum dum)
        {
            string query = @"INSERT INTO Nemovitosti.dbo.Dum (NazevInzeratu, Cena, VelikostPozemku, DatumVytvoreniInzeratu)
                             VALUES (@NazevInzeratu, @Cena, @VelikostPozemku, @DatumVytvoreniInzeratu)
                             SELECT IdDum FROM Nemovitosti.dbo.Dum WHERE Dum.IdDum = Scope_Identity()";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                dum.DatumVytvoreniInzeratu = DateTime.Now;
                Dum dumZDb = dbConnection.Query<Dum>(query, new { dum.IdDum, dum.NazevInzeratu, dum.Cena, dum.VelikostPozemku, dum.DatumVytvoreniInzeratu }).SingleOrDefault();
                dum.IdDum = dumZDb.IdDum;
            }
        }

        public Dum GetById(int IdDum)
        {
            string query = @"SELECT Dum.IdDum, Dum.NazevInzeratu, Dum.Cena, Dum.VelikostPozemku, Dum.DatumVytvoreniInzeratu FROM Nemovitosti.dbo.Dum WHERE IdDum = @IdDum";
            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {

                return dbConnection.Query<Dum>(query, new { IdDum }).SingleOrDefault();
            }
        }

        public void Update(Dum dum)
        {
            string query = @"UPDATE Nemovitosti.dbo.Dum SET(NazevInzeratu = @NazevInzeratu, Cena = @Cena, VelikostPozemku = @VelikostPozemku)";

            using (DbConnection dbConnection = new SqlConnection())
            {
                int PocetZmenenychRadku = dbConnection.Execute(query, new { dum.NazevInzeratu, dum.Cena, dum.VelikostPozemku });
                if (PocetZmenenychRadku != 1)
                {
                    throw new Exception();
                }
            }
        }

        public void Delete(Dum dum)
        {
            string query = "DELETE FROM Nemovitosti.dbo.Dum WHERE Dum.IdDum = @IdDum";

            using (DbConnection dbConnection = new SqlConnection(connString.ConnectionString))
            {
                int PocetZmenenychRadku = dbConnection.Execute(query, new { IdDum = dum.IdDum });
                if (PocetZmenenychRadku != 1)
                {
                    throw new Exception();
                }
            }
        }

    }
}
