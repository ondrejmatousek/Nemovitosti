using Dapper;
using Microsoft.Extensions.Configuration;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Nemovitosti.DataAccessLayer.Implementation
{
    public class BytDao : IBytDao
    {
        private readonly IConfiguration Configuration;

        public BytDao(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void Insert(Byt byt)
        {
            string query = @"INSERT INTO Nemovitosti.dbo.Byt (NazevInzeratu, Cena, VelikostBytu)
                             VALUES (@NazevInzeratu, @Cena, @VelikostBytu)
                             SELECT IdByt FROM Nemovitosti.dbo.Byt WHERE Byt.IdByt = Scope_Identity()";

            using (DbConnection dbConnection = new SqlConnection(Configuration.GetConnectionString("ConnectionString")))
            {
                Byt bytZdb = dbConnection.Query<Byt>(query, new { byt.IdByt, byt.NazevInzeratu, byt.Cena, byt.VelikostBytu }).SingleOrDefault();
                byt.IdByt = bytZdb.IdByt;
            }

        }

        public Byt GetById(int IdByt)
        {
            string query = @"SELECT Byt.IdByt, Byt.NazevInzeratu, Byt.Cena, Byt.VelikostBytu FROM Nemovitosti.dbo.Byt WHERE IdByt = @IdByt";
            using (DbConnection dbConnection = new SqlConnection(Configuration.GetConnectionString("ConnectionString")))
            {
                Byt bytZDb = dbConnection.Query(query, new { IdByt }).SingleOrDefault();
                return bytZDb;
            }
        }

        public void Update(Byt byt)
        {
            string query = @"UPDATE Nemovitosti.dbo.Byt SET(NazevInzeratu = @NazevInzeratu, Cena = @Cena, VelikostBytu = @VelikostBytu) WHERE Byt.IdByt = @IdByt";
            using (DbConnection dbConnection = new SqlConnection(Configuration.GetConnectionString("ConnectionString")))
            {
                Byt bytZDb = dbConnection.Query<Byt>(query, new { byt.IdByt, byt.NazevInzeratu, byt.Cena, byt.VelikostBytu }).SingleOrDefault();
            }
        }

        public void Delete(Byt byt)
        {
            string query = "DELETE FROM Nemovitosti.dbo.Byt WHERE Byt.IdByt = @IdByt";
            using (DbConnection dbConnection = new SqlConnection(Configuration.GetConnectionString("ConnectionString")))
            {
                int PocetVymazanychRadku = dbConnection.Execute(query, new { byt.IdByt });
            }
        }
    }
}
